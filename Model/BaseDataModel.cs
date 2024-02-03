using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.DouYin.Enum;
using XiaoFeng.Json;
using XiaoFeng.Memcached;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 20:40:17                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 基础模型
    /// </summary>
    public class BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public BaseDataModel()
        {

        }
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        public BaseDataModel(AccessTokenErrorCode errorCode, string description)
        {
            ErrorCode = errorCode;
            Description = description;
        }

        #endregion

        #region 属性
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonElement("error_code")]
        public AccessTokenErrorCode ErrorCode { get; set; }
        /// <summary>
        /// 错误码描述
        /// </summary>
        [JsonElement("description")]
        public string Description { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化一个新的实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="description">错误码描述</param>
        /// <remarks>返回一个新实例</remarks>
        public static BaseDataModel Create(AccessTokenErrorCode errorCode, string description) =>new BaseDataModel(errorCode, description);
        #endregion
    }
}