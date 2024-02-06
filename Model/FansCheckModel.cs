using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-06 21:38:47                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// 粉丝验证模型
    /// </summary>
    public class FansCheckModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public FansCheckModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 是否关注
        /// </summary>
        [JsonElement("is_follower")]
        public Boolean IsFollower { get; set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        [JsonElement("follow_time")]
        public long FollowerTime { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}