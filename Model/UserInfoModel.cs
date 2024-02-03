using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XiaoFeng.DouYin.Enum;
using XiaoFeng.IO;
using XiaoFeng.Json;

/****************************************************************
*  Copyright © (2023) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2023-12-30 21:06:26                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Model
{
    /// <summary>
    /// UserInfoModel 类说明
    /// </summary>
    public class UserInfoModel:BaseDataModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserInfoModel()
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 用户头像
        /// </summary>
        [JsonElement("avatar")]
        public string Avatar { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [JsonElement("nickname")]
        public string NickName { get; set; }
        /// <summary>
        /// 用户在当前应用的唯一标识
        /// </summary>
        [JsonElement("open_id")]
        public string OpenId { get; set; }
        /// <summary>
        /// 帐号类型
        /// </summary>
        [JsonElement("e_account_role")]
        public AccountRole AccountRole { get; set; }
        /// <summary>
        /// 用户在当前开发者账号下的唯一标识（未绑定开发者账号没有该字段）
        /// </summary>
        [JsonElement("union_id")]
        public string UnionId { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        [JsonElement("encrypt_mobile ")]
        public string EncryptMobile { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="client_secret">私钥</param>
        /// <returns></returns>
        public string GetMobile(string client_secret)
        {
            if (this.EncryptMobile.IsNullOrEmpty()) return string.Empty;
            return this.EncryptMobile.AESDecrypt(client_secret, client_secret.GetBytes().ReadBytes(0, 16).GetString());
        }
        #endregion
    }
}