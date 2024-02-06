using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.DouYin.Enum;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-06 22:03:47                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// ClientToken 模型
    /// </summary>
    public class ClientTokenModel : BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public ClientTokenModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public ClientTokenModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="accessToken">接口调用凭证</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="expiresIn">接口调用凭证超时时间，单位（秒)</param>
        /// <param name="message">消息</param>
        /// <param name="description">错误码描述</param>
        public ClientTokenModel(string accessToken, AccessTokenErrorCode errorCode, long expiresIn, string message, string description) : base(errorCode, description)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            Message = message;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [JsonElement("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 接口调用凭证超时时间，单位（秒)
        /// </summary>
        [JsonElement("expires_in")]
        public long ExpiresIn { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [JsonElement("message")]
        public string Message { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}