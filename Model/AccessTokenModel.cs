using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.DouYin.Enum;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 19:58:37                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /*
     * 正确的
{
    "data": {
        "access_token": "act.f7094fbffab2ecbfc45e9af9c32bc241oYdckvBKe82BPx8T******",
        "captcha": "",
        "desc_url": "",
        "description": "",
        "error_code": 0,
        "expires_in": 1296000,
        "log_id": "20230525105733ED3ED7AC56A******",
        "open_id": "b9b71865-7fea-44cc-******",
        "refresh_expires_in": 2592000,
        "refresh_token": "rft.713900b74edde9f30ec4e246b706da30t******",
        "scope": "user_info"
    },
    "message": "success"
}
    错误的
 {
  "data": {
    "description": "Parameter error",
    "error_code": 2100005
  },
  "extra": {
    "logid": "2020070614111601022506808001045D59",
    "now": 1594015876138
  }
}
     */
    /// <summary>
    /// AccessToken 模型
    /// </summary>
    public class AccessTokenModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public AccessTokenModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="accessToken">接口调用凭证</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="expiresIn">接口调用凭证超时时间，单位（秒)</param>
        /// <param name="openId">授权用户唯一标识</param>
        /// <param name="refreshExpiresIn">凭证超时时间，单位（秒)</param>
        /// <param name="refreshToken">用户刷新 access_token</param>
        /// <param name="scope">用户授权的作用域（Scope），使用逗号（,）分隔，开放平台几乎每个接口都需要特定的 Scope。</param>
        /// <param name="description">错误码描述</param>
        public AccessTokenModel(string accessToken, AccessTokenErrorCode errorCode, long expiresIn, string openId, long refreshExpiresIn, string refreshToken, string scope, string description):base(errorCode,description)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            OpenId = openId;
            RefreshExpiresIn = refreshExpiresIn;
            RefreshToken = refreshToken;
            Scope = scope;
        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public AccessTokenModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }

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
        /// 授权用户唯一标识
        /// </summary>
        [JsonElement("open_id")]
        public string OpenId { get; set; }
        /// <summary>
        /// 凭证超时时间，单位（秒)
        /// </summary>
        [JsonElement("refresh_expires_in")]
        public long RefreshExpiresIn { get; set; }
        /// <summary>
        /// 用户刷新 access_token
        /// </summary>
        [JsonElement("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// 用户授权的作用域（Scope），使用逗号（,）分隔，开放平台几乎每个接口都需要特定的 Scope。
        /// </summary>
        [JsonElement("scope")]
        public string Scope { get; set; }
       
        #endregion

        #region 方法

        #endregion
    }
}