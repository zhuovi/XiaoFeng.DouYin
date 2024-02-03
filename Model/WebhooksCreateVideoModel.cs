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
*  Create Time : 2024-02-02 23:34:10                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 分享视频
    /// </summary>
    public class WebhooksCreateVideoModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public WebhooksCreateVideoModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 创建的视频id
        /// </summary>
        [JsonElement("item_id")]
        public string ItemId { get; set; }
        /// <summary>
        /// 标识分享的share_id
        /// </summary>
        [JsonElement("share_id")]
        public string ShareId { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}