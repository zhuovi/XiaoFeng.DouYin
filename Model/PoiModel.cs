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
*  Create Time : 2024-02-02 21:24:23                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 地点信息模型
    /// </summary>
    public class PoiModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public PoiModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public PoiModel(AccessTokenErrorCode errorCode, string description) : base(errorCode, description) { }
        #endregion

        #region 属性
        /// <summary>
        /// 下一页请求
        /// </summary>
        [JsonElement("cursor")]
        public int Cursor { get; set; }
        /// <summary>
        /// 是否有更多的数据
        /// </summary>
        [JsonElement("has_more")]
        public Boolean HasMore { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        [JsonElement("pois")]
        public List<PoiInfoModel> Pois { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    public class PoiInfoModel
    {
        /// <summary>
        /// 国家
        /// </summary>
        [JsonElement("country")]
        public string Country {  get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [JsonElement("district")]
        public string District { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        [JsonElement("province")]
        public string Province {  get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [JsonElement("address")]
        public string Address { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        [JsonElement("city_code")]
        public string CityCode { get;set; }
        /// <summary>
        /// 经纬度，格式：X,Y
        /// </summary>
        [JsonElement("location")]
        public string Location {  get; set; }
        /// <summary>
        /// 唯一ID
        /// </summary>
        [JsonElement("poi_id")]
        public string PoiId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [JsonElement("poi_name")]
        public string PoiName { get; set;}
        /// <summary>
        /// 城市
        /// </summary>
        [JsonElement("city")]
        public string City { get; set; }
        /// <summary>
        /// 国家编码
        /// </summary>
        [JsonElement("country_code")]
        public string CountryCode { get; set; }
    }
}