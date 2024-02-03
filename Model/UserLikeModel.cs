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
    /// 用户点赞数
    /// </summary>
    public class UserLikeModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserLikeModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public UserLikeModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("result_list")]
        public List<UserLikeInfoModel> ResultList { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 数据
    /// </summary>
    public class UserLikeInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonElement("date")]
        public string Date { get; set; }
        /// <summary>
        /// 新增点赞
        /// </summary>
        [JsonElement("new_like")]
        public long NewLike { get; set; }
    }
}