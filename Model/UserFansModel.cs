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
*  Create Time : 2024-02-02 21:57:48                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 用户粉丝数
    /// </summary>
    public class UserFansModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserFansModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public UserFansModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("result_list")]
        public List<UserFansInfoModel> ResultList { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 数据
    /// </summary>
    public class UserFansInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonElement("date")]
        public string Date { get; set; }
        /// <summary>
        /// 每天新粉丝数
        /// </summary>
        [JsonElement("new_fans")]
        public long NewFans { get; set; }
        /// <summary>
        /// 每日总粉丝数
        /// </summary>
        [JsonElement("total_fans")]
        public long TotalFans { get; set; }
    }
}