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
    /// 视频基础数据
    /// </summary>
    public class ItemBaseModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public ItemBaseModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public ItemBaseModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 数据
        /// </summary>
        [JsonElement("result")]
        public UserItemBaseInfoModel Result { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 数据
    /// </summary>
    public class UserItemBaseInfoModel
    {
        /// <summary>
        /// 最近30天分享数
        /// </summary>
        [JsonElement("total_share")]
        public long TotalShare { get; set; }
        /// <summary>
        /// 最近30天平均播放时长
        /// </summary>
        [JsonElement("avg_play_duration")]
        public double AvgPlayDuration { get; set; }
        /// <summary>
        /// 最近30天播放次数
        /// </summary>
        [JsonElement("total_play")]
        public long TotalPlay { get; set; }
        /// <summary>
        /// 最近30天点赞数
        /// </summary>
        [JsonElement("total_like")]
        public long TotalLike { get; set; }
        /// <summary>
        /// 最近30天评论数
        /// </summary>
        [JsonElement("total_comment")]
        public long TotalComment { get; set; }
    }
}