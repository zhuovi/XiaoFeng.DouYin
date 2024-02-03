using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 19:44:24                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Internal
{
    /// <summary>
    /// 公共类
    /// </summary>
    public static class Helper
    {
        #region 公共属性
        /// <summary>
        /// API域名
        /// </summary>
        public const string API_DOMAIN = "https://open.douyin.com/";
        #endregion

        #region 方法
        public static async Task<T> Execute<T>(string url, Func<T, Task> func)
        {
            return default(T);
        }
        #endregion
    }
}