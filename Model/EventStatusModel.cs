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
*  Create Time : 2024-02-02 00:26:09                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// EventStatusModel 类说明
    /// </summary>
    public class EventStatusModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public EventStatusModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public EventStatusModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("list")]
        public List<EventStatus> List { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 事件结构
    /// </summary>
    public class EventStatus
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        [JsonElement("event")]
        public string Event{ get;set; }
        /// <summary>
        /// 事件订阅状态 * `0` - 未订阅 * `1` - 已订阅
        /// </summary>
        [JsonElement("status")]
        public int Status { get; set; }
    }
}