using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng.Config;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 19:47:49                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// OpenAPI配置
    /// </summary>
    [ConfigFile("Config/DouYinOpenApiConfig.json", 0, "FAYELF-CONFIG-DOUYIN-OPENAPI-CONFIG", ConfigFormat.Json)]
    public class OpenApiOptions : ConfigSet<OpenApiOptions>
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public OpenApiOptions()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 应用唯一标识
        /// </summary>
        [Description("应用唯一标识")]
        public string ClientKey { get; set; }
        /// <summary>
        /// 应用唯一标识对应的密钥
        /// </summary>
        [Description("应用唯一标识对应的密钥")]
        public string ClientSecret { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}