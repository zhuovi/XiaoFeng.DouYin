using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 20:35:29                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 结果模型
    /// </summary>
    public class ResultModel<T>
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public ResultModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 消息
        /// </summary>
        [JsonElement("message")]
        public string Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        [JsonElement("data")]
        public T Data { get; set; }
        /// <summary>
        /// 异常数据
        /// </summary>
        [JsonElement("extra")]
        public Extra Extra { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 异常类
    /// </summary>
    public class Extra
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        [JsonElement("logid")]
        public string LogId { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        [JsonElement("now")]
        public Int64 Now { get; set; }
    }
}