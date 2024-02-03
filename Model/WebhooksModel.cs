using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-02 23:30:34                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// WebHooks基础模型
    /// </summary>
    public class WebhooksModel<T> where T : class
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public WebhooksModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 事件
        /// </summary>
        [JsonElement("event")]
        public string Event { get; set; }
        /// <summary>
        /// 用户Id 就是openid
        /// </summary>
        [JsonElement("from_user_id")]
        public string FromUserId { get; set; }
        /// <summary>
        /// ClientKey
        /// </summary>
        [JsonElement("client_key")]
        public string ClientKey { get; set; }
        /// <summary>
        /// 消息Id
        /// </summary>
        [JsonElement("msg_id")]
        public string MsgId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [JsonElement("content")]
        public T Content { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}