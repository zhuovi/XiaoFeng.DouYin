using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-02 20:54:44                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Enum
{
    /// <summary>
    /// 视频状态
    /// </summary>
    public enum VideoStatus
    {
        /// <summary>
        /// 已发布
        /// </summary>
        Published = 1,
        /// <summary>
        /// 不适宜公开
        /// </summary>
        NonPublic = 2,
        /// <summary>
        /// 审核中
        /// </summary>
        InReview = 4,
        /// <summary>
        /// 公开视频
        /// </summary>
        Public = 5
    }
}