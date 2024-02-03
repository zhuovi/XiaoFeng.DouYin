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
*  Create Time : 2024-02-02 22:39:19                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 热门视频榜
    /// </summary>
    public class HotVideoModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public HotVideoModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public HotVideoModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("list")]
        public List<HotVideoInfoModel> List { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 数据
    /// </summary>
    public class HotVideoInfoModel
    {
        /// <summary>
        /// 视频发布者
        /// </summary>
        [JsonElement("author")]
        public string Author { get; set; }
        /// <summary>
        /// 点赞数，离线数据（统计前一日数据）
        /// </summary>
        [JsonElement("digg_count")] 
        public long DiggCount { get; set; }
        /// <summary>
        /// 视频封面图
        /// </summary>
        [JsonElement("item_conver")] 
        public string ItemConver { get; set; }
        /// <summary>
        /// 播放数，离线数据（统计前一日数据）
        /// </summary>
        [JsonElement("play_count")] 
        public long PlayCount { get; set; }
        /// <summary>
        /// 评论数，离线数据（统计前一日数据）
        /// </summary>
        [JsonElement("comment_count")] 
        public long CommentCount { get; set; }
        /// <summary>
        /// 视频热词（以,隔开）
        /// </summary>
        [JsonElement("hot_words")] 
        public string HotWords {  get; set; }
        /// <summary>
        /// 热度指数
        /// </summary>
        [JsonElement("hot_value")] 
        public double HotValue { get; set; }
        /// <summary>
        /// 排名
        /// </summary>
        [JsonElement("rank")] 
        public int Rank { get; set; }
        /// <summary>
        /// 视频播放页面。视频播放页可能会失效，请在观看视频前调用查询特定视频的视频数据获取最新的播放页。
        /// </summary>
        [JsonElement("share_url")] 
        public string ShareUrl {  get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        [JsonElement("title")]
        public string Title { get; set; }
    }
}