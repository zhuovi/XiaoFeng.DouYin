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
*  Create Time : 2024-02-02 21:48:43                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 用户视频情况
    /// </summary>
    public class UserItemModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserItemModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public UserItemModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("result_list")]
        public List<UserItemInfoModel> ResultList { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    public class UserItemInfoModel
    {
        /// <summary>
        /// 日期
        /// </summary>
        [JsonElement("date")]
        public string Date { get; set; }
        /// <summary>
        /// 每日发布内容数
        /// </summary>
        [JsonElement("new_issue")]
        public long NewIssue { get; set; }
        /// <summary>
        /// 每日新增视频播放
        /// </summary>
        [JsonElement("new_play")]
        public long NewPlay { get; set; }
        /// <summary>
        /// 每日总发布数据
        /// </summary>
        [JsonElement("total_issue")]
        public long TotalIssue { get; set; }
    }
}