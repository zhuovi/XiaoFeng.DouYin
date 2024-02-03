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
*  Create Time : 2024-02-02 22:02:32                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 用户主页访问数
    /// </summary>
    public class UserProfileModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserProfileModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public UserProfileModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("result_list")]
        public List<UserProfileInfoModel> ResultList { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 数据
    /// </summary>
    public class UserProfileInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonElement("date")]
        public string Date { get; set; }
        /// <summary>
        /// 当日个人主页访问人数
        /// </summary>
        [JsonElement("profile_uv")]
        public long ProfileUV { get; set; }
    }
}