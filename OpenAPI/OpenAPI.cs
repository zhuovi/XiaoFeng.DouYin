using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.DouYin.Enum;
using XiaoFeng.DouYin.Internal;
using XiaoFeng.DouYin.Model;
using XiaoFeng.Http;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 19:46:12                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin
{
    /// <summary>
    /// OpenAPI
    /// </summary>
    public class OpenAPI
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public OpenAPI()
        {
            this.Options = OpenApiOptions.Current;
        }
        #endregion

        #region 属性
        /// <summary>
        /// OpenApi配置
        /// </summary>
        public OpenApiOptions Options { get; set; }
        /// <summary>
        /// AccessToken
        /// </summary>
        public AccessTokenModel AccessToken { get; set; }
        /// <summary>
        /// 客户端AccessToken
        /// </summary>
        public ClientTokenModel ClientToken { get; set; }
        /// <summary>
        /// 票据
        /// </summary>
        public TicketModel Ticket { get; set; }
        /// <summary>
        /// Token改变事件
        /// </summary>
        public Action<AccessTokenModel, ClientTokenModel, TicketModel> TokenChange { get; set; }
        #endregion

        #region 方法

        #region 用户授权

        #region 获取AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code">授权码</param>
        /// <returns></returns>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string code)
        {
            var result = await new HttpRequest
            {
                ContentType = "application/json",
                Method = "POST",
                Address = $"{Helper.API_DOMAIN}/oauth/access_token/",
                Data = new Dictionary<string, string>
                {
                    {"client_key",this.Options.ClientKey },
                    {"client_secret",this.Options.ClientSecret },
                    {"code",code },
                    {"grant_type","authorization_code" }
                }
            }.GetResponseAsync().ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultModel = result.Html.JsonToObject<ResultModel<AccessTokenModel>>();
                if (resultModel.Data.ErrorCode == Enum.AccessTokenErrorCode.SUCCESS) this.AccessToken = resultModel.Data;
                return resultModel.Data;
            }
            else
                return await Task.FromResult(new AccessTokenModel(Enum.AccessTokenErrorCode.SYSTEM_ERROR, "请求不通"));
        }
        #endregion

        #region 刷新Refresh_Token
        /// <summary>
        /// 刷新Refresh_Token
        /// </summary>
        /// <param name="refreshToken">填写通过 access_token 获取到的 refresh_token 参数</param>
        /// <returns></returns>
        public async Task<RefreshAccessTokenModel> RefreshRefreshAccessTokenAsync(string refreshToken)
        {
            var result = await new HttpRequest
            {
                Method = "POST",
                ContentType = "application/x-www-form-urlencoded",
                Address = $"{Helper.API_DOMAIN}/oauth/renew_refresh_token/",
                Data = new Dictionary<string, string>
                {
                    {"client_key",this.Options.ClientKey },
                    {"refresh_token",refreshToken },
                }
            }.GetResponseAsync().ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultModel = result.Html.JsonToObject<ResultModel<RefreshAccessTokenModel>>();
                if (resultModel.Data.ErrorCode == AccessTokenErrorCode.SUCCESS)
                {
                    this.AccessToken.RefreshToken = resultModel.Data.RefreshToken;
                    this.AccessToken.RefreshExpiresIn = resultModel.Data.ExpiresIn;
                }
                return await Task.FromResult(resultModel.Data);
            }
            else
            {
                return await Task.FromResult((RefreshAccessTokenModel)RefreshAccessTokenModel.Create(Enum.AccessTokenErrorCode.SYSTEM_ERROR, "接口请求不通."));
            }
        }
        #endregion

        #region 生成 client_token
        /// <summary>
        /// 生成 client_token
        /// </summary>
        /// <returns></returns>
        public async Task<ClientTokenModel> CreateClientTokenAsync()
        {
            var result = await new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/oauth/client_token/",
                ContentType = "application/json",
                Data = new Dictionary<string, string>
                {
                    {"grant_type","client_credential" },
                    {"client_key",this.Options.ClientKey },
                    {"client_secret",this.Options.ClientSecret }
                }
            }.GetResponseAsync().ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultModel = result.Html.JsonToObject<ResultModel<ClientTokenModel>>();
                if (resultModel.Data.ErrorCode == AccessTokenErrorCode.SUCCESS)
                {
                    this.ClientToken = resultModel.Data;
                }
                return resultModel.Data;
            }
            else
                return await Task.FromResult(new ClientTokenModel(Enum.AccessTokenErrorCode.SYSTEM_ERROR, "接口请求不通"));
        }
        #endregion

        #region 刷新 access_token
        /// <summary>
        /// 刷新 access_token
        /// </summary>
        /// <param name="refreshToken">填写通过 access_token 获取到的 refresh_token 参数</param>
        /// <returns></returns>
        public async Task<AccessTokenModel> RefreshAccessTokenAsync(string refreshToken)
        {
            var result = await new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/oauth/refresh_token/",
                ContentType = "application/json",
                Data = new Dictionary<string, string>
                {
                    {"grant_type","refresh_token" },
                    {"client_key",this.Options.ClientKey },
                    {"refresh_token",refreshToken }
                }
            }.GetResponseAsync().ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultModel = result.Html.JsonToObject<ResultModel<AccessTokenModel>>();
                if (resultModel.Data.ErrorCode == AccessTokenErrorCode.SUCCESS)
                    this.AccessToken = resultModel.Data;
                else if (resultModel.Data.ErrorCode == AccessTokenErrorCode.REFRESH_TOKEN_EXPIRED)
                {
                    var refreshTokens = await this.RefreshRefreshAccessTokenAsync(this.AccessToken.RefreshToken).ConfigureAwait(false);
                    if (refreshTokens.ErrorCode == AccessTokenErrorCode.SUCCESS)
                    {
                        return await this.RefreshAccessTokenAsync(refreshTokens.RefreshToken).ConfigureAwait(false);
                    }
                }
                return resultModel.Data;
            }
            else
                return await Task.FromResult(new AccessTokenModel(Enum.AccessTokenErrorCode.SYSTEM_ERROR, "接口请求不通"));
        }
        #endregion

        #region 获取 OpenTicket
        /// <summary>
        /// 获取OpenTicket
        /// </summary>
        /// <param name="clientToken">accessToken</param>
        /// <returns></returns>
        public async Task<TicketModel> GetOpenTicketAsync(string clientToken)
        {
            return await this.ExecuteClientTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/open/getticket/",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",clientToken }
                }
            }, async token =>
            {
                return await this.GetOpenTicketAsync(token.AccessToken).ConfigureAwait(false);
            });
        }
        #endregion

        #endregion

        #region webhooks

        #region 获取事件订阅状态
        /// <summary>
        /// 获取事件订阅状态
        /// </summary>
        /// <param name="clientToken">clientToken</param>
        /// <returns></returns>
        public async Task<EventStatusModel> GetEventStatusAsync(string clientToken)
        {
            return await this.ExecuteClientTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/event/status/list/",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",clientToken }
                }
            }, async token =>
            {
                return await this.GetEventStatusAsync(token.AccessToken).ConfigureAwait(false);
            });
        }
        #endregion

        #region 更新事件状态
        /// <summary>
        /// 更新事件状态
        /// </summary>
        /// <param name="clientToken">clientToken</param>
        /// <param name="eventStatus">事件状态</param>
        /// <returns></returns>
        public async Task<BaseDataModel> UpdateEventStatusAsync(string clientToken, List<EventStatus> eventStatus)
        {
            return await ExecuteClientTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/event/status/update/",
                ContentType = "application/json",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",clientToken }
                },
                BodyData = eventStatus.ToJson()
            }, async token =>
            {
                return await this.UpdateEventStatusAsync(clientToken, eventStatus).ConfigureAwait(false);
            });
        }
        #endregion

        #endregion

        #region 用户管理

        #region 获取用户公开信息
        /// <summary>
        /// 获取用户公开信息
        /// </summary>
        /// <param name="accessToken">Token模型 调用 /oauth/access_token/ 生成的 token，此 token 需要用户授权</param>
        /// <returns></returns>
        /// <remarks><para>需要申请权限。</para>
        ///<para>路径：抖音开放平台控制台 > 应用详情 > 能力管理 > 用户权限 > 授权登录与用户基础信息</para>
        ///<para>需要用户授权</para>
        ///</remarks>
        public async Task<UserInfoModel> GetUserInfoAsync(AccessTokenModel accessToken)
        {
            return await ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/oauth/userinfo/",
                ContentType = "application/x-www-form-urlencoded",
                Data = new Dictionary<string, string>
                {
                    {"access_token",accessToken.AccessToken },
                    {"open_id",accessToken.OpenId }
                }
            }, async token =>
            {
                return await this.GetUserInfoAsync(token).ConfigureAwait(false);
            });
        }
        #endregion

        #region 粉丝判断
        /// <summary>
        /// 粉丝判断
        /// </summary>
        /// <param name="accessToken">调用/oauth/access_token/生成，需要用户授权。</param>
        /// <param name="followerOpenId">目标粉丝用户的 open_id。</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>需要申请权限。</para>
        ///<para>路径：抖音开放平台控制台 > 应用详情 > 能力管理 > 用户权限 > 粉丝判断</para>
        ///<para>需要用户授权</para>
        /// </remarks>
        public async Task<FansCheckModel> FansCheckAsync(AccessTokenModel accessToken, string followerOpenId)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                ContentType = "application/json",
                Address = $"{Helper.API_DOMAIN}/fans/check/",
                Method = HttpMethod.Post,
                Data = new Dictionary<string, string>
                {
                    {"access-token", accessToken.AccessToken},
                    {"follower_open_id",followerOpenId },
                    {"open_id",accessToken.OpenId }
                }
            }, async token =>
            {
                return await this.FansCheckAsync(token, followerOpenId).ConfigureAwait(false);
            });
        }
        #endregion

        #region 用户经营身份管理

        #endregion

        #endregion

        #region 视频管理

        #region 创建图文

        #endregion

        #region 图片上传

        #endregion

        #region 上传视频

        #endregion

        #region 上传视频

        #endregion

        #region 分片上传

        #endregion

        #region 分片上传完成

        #endregion

        #region 分片上传初始化

        #endregion

        #endregion

        #region 查询视频

        #region 查询授权账号视频列表
        /// <summary>
        /// 查询授权账号视频列表
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openid</param>
        /// <param name="page">页数</param>
        /// <param name="limit">每条多少条</param>
        /// <returns></returns>
        public async Task<VideoModel> GetVideoListAsync(string accessToken, string openId, int page, int limit)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/api/douyin/v1/video/video_list/",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",this.AccessToken.AccessToken }
                },
                Data = new Dictionary<string, string>
                {
                    {"open_id",this.AccessToken.OpenId },
                    {"cursor",page.ToString() },
                    {"count",limit.ToString() }
                }
            }, async token =>
            {
                return await this.GetVideoListAsync(accessToken, openId, page, limit).ConfigureAwait(false);
            });
        }
        #endregion

        #region 查询特定视频的视频数据
        /// <summary>
        /// 查询特定视频的视频数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openid</param>
        /// <param name="itemIds">item_id 数组，仅能查询 access_token 对应用户上传的视频（与video_ids字段二选一，平台优先处理item_ids）多个用,隔开</param>
        /// <param name="videoIds">video_id 数组，仅能查询 access_token 对应用户上传的视频（与item_ids字段二选一，平台优先处理item_ids）多个用,隔开</param>
        /// <returns></returns>
        public async Task<VideoModel> GetVideoDataAsync(string accessToken, string openId, string itemIds, string videoIds)
        {
            return await ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/api/douyin/v1/video/video_data/?open_id={openId}",
                ContentType = "application/json",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                },
                BodyData = new
                {
                    item_ids = itemIds,
                    video_ids = videoIds
                }.ToJson()
            }, async token =>
            {
                return await this.GetVideoDataAsync(token.AccessToken, token.OpenId, itemIds, videoIds).ConfigureAwait(false);
            });
        }
        #endregion

        #region 查询视频发布结果
        /// <summary>
        /// 查询视频发布结果
        /// </summary>
        /// <param name="clientToken">ClientToken</param>
        /// <param name="needCallback">如果需要知道视频分享成功的结果，need_callback设置为true</param>
        /// <param name="sourceStyleId">多来源样式id（暂未开放）</param>
        /// <param name="defaultHashTag">追踪分享默认hashtag</param>
        /// <param name="linkParam">分享来源url附加参数（暂未开放）</param>
        /// <returns></returns>
        public async Task<ShareModel> GetShareIdAsync(string clientToken, Boolean needCallback = true, string sourceStyleId = "", string defaultHashTag = "", string linkParam = "")
        {
            return await this.ExecuteClientTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/share-id/?need_callback={needCallback.ToString().ToLower()}&source_style_id={sourceStyleId}&default_hashtag={defaultHashTag}&link_param={linkParam}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",clientToken }
                }
            }, async token =>
            {
                return await this.GetShareIdAsync(token.AccessToken, needCallback, sourceStyleId, defaultHashTag, linkParam).ConfigureAwait(false);
            });
        }
        #endregion

        #region 查询视频携带的地点信息
        /// <summary>
        /// 查询视频携带的地点信息
        /// </summary>
        /// <param name="clientToken">ClientToken</param>
        /// <param name="keyword">查询关键字，例如美食</param>
        /// <param name="city">查询城市，例如上海、北京</param>
        /// <param name="page">分页游标, 第一页请求cursor是0, response中会返回下一页请求用到的cursor, 同时response还会返回has_more来表明是否有更多的数据。</param>
        /// <param name="limit">每页数量</param>
        /// <returns></returns>
        public async Task<PoiModel> GetPoiAsync(string clientToken, string keyword, string city, int page, int limit)
        {
            return await this.ExecuteClientTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/poi/search/keyword/",
                ContentType = "application/json",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",clientToken }
                },
                Data = new Dictionary<string, string>
                {
                    {"cursor",page.ToString() },
                    {"count",limit.ToString() },
                    {"keyword",keyword },
                    {"city",city }
                }
            }, async token =>
            {
                return await this.GetPoiAsync(token.AccessToken, keyword, city, page, limit).ConfigureAwait(false);
            });
        }
        #endregion

        #region 通过VideoID获取IFrame代码

        #endregion

        #region 通过ItemID获取IFrame代码

        #endregion

        #endregion

        #region 评论管理

        #region 置顶评论

        #endregion

        #region 评论列表

        #endregion

        #region 评论回复列表

        #endregion

        #region 回复视频评论

        #endregion

        #region 接收评论回复事件

        #endregion

        #endregion

        #region 搜索管理

        #region 关键词视频搜索

        #endregion

        #region 关键词视频评论列表

        #endregion

        #region 关键词视频评论回复

        #endregion

        #region 关键词视频评论回复列表

        #endregion


        #endregion

        #region 数据开放服务

        #region 用户数据

        #region 获取用户视频情况
        /// <summary>
        /// 获取用户视频情况
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="days">近7/15/30天；输入7代表7天、15代表15天、30代表30天。</param>
        /// <returns></returns>
        public async Task<UserItemModel> GetUserItemAsync(string accessToken, string openId, int days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/user/item/?open_id={openId}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetUserItemAsync(token.AccessToken, token.OpenId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取用户粉丝数
        /// <summary>
        /// 获取用户粉丝数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="days">近7/15/30天；输入7代表7天、15代表15天、30代表30天。</param>
        /// <returns></returns>
        public async Task<UserFansModel> GetUserFansAsync(string accessToken, string openId, int days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/user/fans/?open_id={openId}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetUserFansAsync(token.AccessToken, token.OpenId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取用户点赞数
        /// <summary>
        /// 获取用户点赞数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="days">近7/15/30天；输入7代表7天、15代表15天、30代表30天。</param>
        /// <returns></returns>
        public async Task<UserLikeModel> GetUserLikeAsync(string accessToken, string openId, int days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/user/like/?open_id={openId}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetUserLikeAsync(token.AccessToken, token.OpenId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取用户评论数
        /// <summary>
        /// 获取用户评论数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="days">近7/15/30天；输入7代表7天、15代表15天、30代表30天。</param>
        /// <returns></returns>
        public async Task<UserCommentModel> GetUserCommentAsync(string accessToken, string openId, int days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/user/comment/?open_id={openId}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetUserCommentAsync(token.AccessToken, token.OpenId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取用户分享数
        /// <summary>
        /// 获取用户分享数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="days">近7/15/30天；输入7代表7天、15代表15天、30代表30天。</param>
        /// <returns></returns>
        public async Task<UserShareModel> GetUserShareAsync(string accessToken, string openId, int days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/user/share/?open_id={openId}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetUserShareAsync(token.AccessToken, token.OpenId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取用户主页访问数
        /// <summary>
        /// 获取用户主页访问数
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="days">近7/15/30天；输入7代表7天、15代表15天、30代表30天。</param>
        /// <returns></returns>
        public async Task<UserProfileModel> GetUserProfileAsync(string accessToken, string openId, int days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/user/profile/?open_id={openId}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetUserProfileAsync(token.AccessToken, token.OpenId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #endregion

        #region 视频数据

        #region 获取视频基础数据
        /// <summary>
        /// 获取视频基础数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="itemId">item_id，仅能查询access_token对应用户上传的视频</param>
        /// <returns></returns>
        public async Task<ItemBaseModel> GetItemBaseAsync(string accessToken, string openId, string itemId)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/item/base/?open_id={openId}&item_id={itemId.UrlEncode()}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetItemBaseAsync(token.AccessToken, token.OpenId, itemId).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取视频点赞数据
        /// <summary>
        /// 获取视频点赞数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="itemId">item_id，仅能查询access_token对应用户上传的视频</param>
        /// <param name="days">数据范围，只支持近7/15/30天</param>
        /// <returns></returns>
        public async Task<ItemLikeModel> GetItemLikeAsync(string accessToken, string openId, string itemId, string days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/item/like/?open_id={openId}&item_id={itemId.UrlEncode()}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetItemLikeAsync(token.AccessToken, token.OpenId, itemId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取视频评论数据
        /// <summary>
        /// 获取视频评论数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="itemId">item_id，仅能查询access_token对应用户上传的视频</param>
        /// <param name="days">数据范围，只支持近7/15/30天</param>
        /// <returns></returns>
        public async Task<ItemCommentModel> GetItemCommentAsync(string accessToken, string openId, string itemId, string days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/ data/external/item/comment/?open_id={openId}&item_id={itemId.UrlEncode()}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetItemCommentAsync(token.AccessToken, token.OpenId, itemId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取视频播放数据
        /// <summary>
        /// 获取视频播放数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="itemId">item_id，仅能查询access_token对应用户上传的视频</param>
        /// <param name="days">数据范围，只支持近7/15/30天</param>
        /// <returns></returns>
        public async Task<ItemPlayModel> GetItemPlayAsync(string accessToken, string openId, string itemId, string days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/item/play/?open_id={openId}&item_id={itemId.UrlEncode()}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetItemPlayAsync(token.AccessToken, token.OpenId, itemId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #region 获取视频分享数据
        /// <summary>
        /// 获取视频分享数据
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="openId">openId</param>
        /// <param name="itemId">item_id，仅能查询access_token对应用户上传的视频</param>
        /// <param name="days">数据范围，只支持近7/15/30天</param>
        /// <returns></returns>
        public async Task<ItemShareModel> GetItemShareAsync(string accessToken, string openId, string itemId, string days)
        {
            return await this.ExecuteAccessTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/external/item/share/?open_id={openId}&item_id={itemId.UrlEncode()}&date_type={days}",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",accessToken }
                }
            }, async token =>
            {
                return await this.GetItemShareAsync(token.AccessToken, token.OpenId, itemId, days).ConfigureAwait(false);
            });
        }
        #endregion

        #endregion

        #region 榜单数据

        #region 热门视频榜
        /// <summary>
        /// 热门视频榜
        /// </summary>
        /// <param name="clientToken">clientToken</param>
        /// <returns></returns>
        public async Task<HotVideoModel> GetHotVideoRankAsync(string clientToken)
        {
            return await this.ExecuteClientTokenAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/data/extern/billboard/hot_video/",
                Headers = new Dictionary<string, string>
                {
                    {"access-token",clientToken }
                }
            }, async token =>
            {
                return await this.GetHotVideoRankAsync(token.AccessToken);
            });
        }
        #endregion

        #endregion

        #endregion

        #region 运行结果

        #region 运行AccessToken结果
        /// <summary>
        /// 运行AccessToken结果
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="request">请求对象</param>
        /// <param name="func">回调方法</param>
        /// <returns></returns>
        public async Task<T> ExecuteAccessTokenAsync<T>(IHttpRequest request, Func<AccessTokenModel, Task<T>> func) where T : BaseDataModel
        {
            var response = await request.GetResponseAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = response.Html.JsonToObject<ResultModel<T>>();
                if (data.Data.ErrorCode == AccessTokenErrorCode.ACCESS_TOKEN_EXPIRED)
                {
                    var client = await this.RefreshAccessTokenAsync(this.AccessToken.RefreshToken).ConfigureAwait(false);
                    if (client.ErrorCode == AccessTokenErrorCode.SUCCESS)
                    {
                        this.AccessToken = client;
                        this.TokenChange?.Invoke(client, null, null);
                        return await func.Invoke(client);
                    }
                    else if (client.ErrorCode == AccessTokenErrorCode.REFRESH_TOKEN_EXPIRED)
                    {
                        var refresh = await this.RefreshRefreshAccessTokenAsync(this.AccessToken.RefreshToken).ConfigureAwait(false);
                        if (refresh.ErrorCode == AccessTokenErrorCode.SUCCESS)
                        {
                            client.RefreshToken = refresh.RefreshToken;
                            client.RefreshExpiresIn = refresh.ExpiresIn;
                            await this.RefreshAccessTokenAsync(this.AccessToken.RefreshToken).ConfigureAwait(false);
                            if (client.ErrorCode == AccessTokenErrorCode.SUCCESS)
                            {
                                this.AccessToken = client;
                                this.TokenChange?.Invoke(client, null, null);
                                return await func.Invoke(client);
                            }
                            else return (T)(client as BaseDataModel);
                        }
                        else return (T)(refresh as BaseDataModel);
                    }
                    else return (T)(client as BaseDataModel);
                }
                return data.Data;
            }
            else
                return await Task.FromResult((T)new BaseDataModel(AccessTokenErrorCode.SYSTEM_ERROR, "接口请求不通"));
        }
        #endregion

        #region 运行ClientToken结果
        /// <summary>
        /// 运行ClientToken结果
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="request">请求对象</param>
        /// <param name="func">回调方法</param>
        /// <returns></returns>
        public async Task<T> ExecuteClientTokenAsync<T>(IHttpRequest request, Func<ClientTokenModel, Task<T>> func) where T : BaseDataModel
        {
            var response = await request.GetResponseAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = response.Html.JsonToObject<ResultModel<T>>();
                if (data.Data.ErrorCode == AccessTokenErrorCode.ACCESSTOKEN_EXPIERD)
                {
                    var client = await this.CreateClientTokenAsync().ConfigureAwait(false);
                    if (client.ErrorCode == AccessTokenErrorCode.SUCCESS)
                    {
                        this.ClientToken = client;
                        this.TokenChange?.Invoke(null, client, null);
                        return await func.Invoke(client);
                    }
                }
                return data.Data;
            }
            else
                return await Task.FromResult((T)new BaseDataModel(AccessTokenErrorCode.SYSTEM_ERROR, "接口请求不通"));
        }
        #endregion

        #endregion

        #endregion
    }
}