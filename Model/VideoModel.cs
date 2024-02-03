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
*  Create Time : 2024-02-02 20:41:34                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 视频模型
    /// </summary>
    public class VideoModel : BaseDataModel
    {
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        public VideoModel() { }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public VideoModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        /// <summary>
        /// 下一页请求
        /// </summary>
        [JsonElement("cursor")]
        public int Cursor { get; set; }
        /// <summary>
        /// 是否有更多
        /// </summary>
        [JsonElement("has_more")]
        public Boolean HasMore {  get; set; }
        /// <summary>
        /// 视频列表
        /// </summary>
        [JsonElement("list")]
        public List<VideoInfoModel> List { get; set; }
    }
    /// <summary>
    /// 视频详情
    /// </summary>
    public class VideoInfoModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public VideoInfoModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 统计数据
        /// </summary>
        [JsonElement("statistics")]
        public Statistics Statistics { get; set; }
        /// <summary>
        /// 媒体类型
        /// </summary>
        [JsonElement("media_type")]
        public MediaType MediaType { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        [JsonElement("item_id")]
        public string ItemId { get; set; }
        /// <summary>
        /// 视频标题
        /// </summary>
        [JsonElement("title")]
        public string Title { get; set; }
        /// <summary>
        /// 视频封面
        /// </summary>
        [JsonElement("cover")]
        public string Conver { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [JsonElement("is_top")]
        public Boolean IsTop { get;set; }
        /// <summary>
        /// 视频创建时间戳
        /// </summary>
        [JsonElement("create_time")]
        public int CreateTime { get; set; }
        /// <summary>
        /// 表示是否审核结束。审核通过或者失败都会返回 true，审核中返回 false。
        /// </summary>
        [JsonElement("is_reviewed")]
        public Boolean IsReviewed { get; set; }
        /// <summary>
        /// 视频状态
        /// </summary>
        [JsonElement("video_status")]
        public VideoStatus VideoStatus { get; set; }
        /// <summary>
        /// 视频播放页面。视频播放页可能会失效，请在观看视频前调用/video/data/获取最新的播放页
        /// </summary>
        [JsonElement("share_url")]
        public string ShareUrl { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 统计数据
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// 点赞数
        /// </summary>
        [JsonElement("digg_count")]
        public int DiggCount { get; set; }
        /// <summary>
        /// 下载数
        /// </summary>
        [JsonElement("download_count")]
        public int DownloadCount { get; set; }
        /// <summary>
        /// 播放数
        /// </summary>
        [JsonElement("play_count")]
        public int PlayCount { get; set; }
        /// <summary>
        /// 分享数
        /// </summary>
        [JsonElement("share_count")]
        public int ShareCount { get; set; }
        /// <summary>
        /// 转发数
        /// </summary>
        [JsonElement("forward_count")]
        public int ForwardCount { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        [JsonElement("comment_count")]
        public int CommentCount { get; set; }
    }
}