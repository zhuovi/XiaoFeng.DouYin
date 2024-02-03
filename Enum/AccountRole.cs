using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 21:08:33                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Enum
{
    /// <summary>
    /// 帐号类型
    /// </summary>
    public enum AccountRole
    {
        /// <summary>
        /// 普通企业号
        /// </summary>
        [Description("普通企业号")]
        EAccountM = 0,
        /// <summary>
        /// 认证企业号
        /// </summary>
        [Description("认证企业号")]
        EAccountS = 1,
        /// <summary>
        /// 品牌企业号
        /// </summary>
        [Description("品牌企业号")]
        EAccountK = 2
    }
}