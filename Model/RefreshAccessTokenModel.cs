using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 20:43:13                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// RefreshAccessToken 模型
    /// </summary>
    public class RefreshAccessTokenModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public RefreshAccessTokenModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 用户刷新 access_token
        /// </summary>
        [JsonElement("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// 接口调用凭证超时时间，单位（秒)
        /// </summary>
        [JsonElement("expires_in")]
        public long ExpiresIn { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}