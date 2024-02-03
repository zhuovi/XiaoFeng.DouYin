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
*  Create Time : 2023-12-30 19:51:22                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.DouYin.Enum
{
    /*
     *HTTP 状态码  错误码        描述               排查建议
     *200          10002       参数错误            看看是否有参数漏传，或者请求的格式不对。
     *200          10003       配置无效            检查 client_key 参数是否正确
     *200          10007       授权码过期          授权码只有 10 分钟有效期，且只能使用一次。
     *200          10013       client_key 或者 client_secret 报错      检查 client_key 和 client_secret 是否正确。
     *200          10014       client_key 不匹配      检查获取授权码使用的 client_key 和获取 access_token 使用的 client_key 是否一致。
     *200          10001        系统异常              服务出现异常，请稍后重试。
     *200          10005        缺少参数              检查是否填写 client_key 和 refresh_token 参数，请求格式是否正确。
     *200          10004        权限不足              请申请 renew_refresh_token 权限。
     *200          10010        refresh_token 过期    token 已过期，请让用户重新授权。
     *200          10020        超过刷新次数限制      无法再刷新，请让用户重新授权。
     */
    /// <summary>
    /// AccessToken 错误码
    /// </summary>
    public enum AccessTokenErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS = 0,
        /// <summary>
        /// <summary>
        /// 系统异常
        /// </summary>
        [Description("系统异常")]
        SYSTEM_ERROR = 10001,
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        PARAM_INVALID = 10002,
        /// <summary>
        /// 配置无效
        /// </summary>
        [Description("配置无效")]
        CONFIGURATION_INVALID = 10003,
        /// <summary>
        /// 权限不足
        /// </summary>
        [Description("权限不足")]
        NO_PERMISSIONS = 10004,
        /// <summary>
        /// 缺少参数
        /// </summary>
        [Description("缺少参数")]
        MISSING_PARAMETER = 10005,
        /// <summary>
        /// 授权码过期
        /// </summary>
        [Description("授权码过期")]
        TOKEN_EXPIRED = 10007,
        /// <summary>
        /// refresh_token 过期
        /// </summary>
        [Description("refresh_token 过期")]
        REFRESH_TOKEN_EXPIRED = 10010,
        /// <summary>
        /// client_key 或者 client_secret 报错
        /// </summary>
        [Description("client_key 或者 client_secret 报错")]
        KEY_SECRET_ERROR = 10013,
        /// <summary>
        /// client_key 不匹配
        /// </summary>
        [Description("client_key 不匹配")]
        KEY_ERROR = 10014,
        /// <summary>
        /// 超过刷新次数限制
        /// </summary>
        [Description("超过刷新次数限制")]
        REFRESH_TOKEN_LIMIT = 10020,
        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        PARAMETER_ERROR = 40001,
        /// <summary>
        /// 操作的用户需在通讯录权限范围中。
        /// </summary>
        [Description("操作的用户需在通讯录权限范围中")]
        NO_USER_AUTHORITY_ERROR = 41050,
        /// <summary>
        /// 参数不合法
        /// </summary>
        [Description("参数不合法")]
        PARAMETER_INVALID= 2100005,
        /// <summary>
        /// 请求参数 access_token openid 不匹配
        /// </summary>
        [Description("请求参数 access_token openid 不匹配")]
        PARAMETER_MISMATCHING_ACCESSTOKEN_OPENID = 2190015,
        /// <summary>
        /// open_id 与 follower_open_id 相同
        /// </summary>
        [Description("open_id 与 follower_open_id 相同")]
        PARAMETER_SAME_OPENID_FOLLOWER_OPENID= 2100006,
        /// <summary>
        /// 系统繁忙，此时请开发者稍候再试
        /// </summary>
        [Description("系统繁忙，此时请开发者稍候再试")]
        SYSTEM_BUSY = 2100004,
        /// <summary>
        /// 无权限操作
        /// </summary>
        [Description("无权限操作")]
        NONE_PERMISSIONS = 2100007,
        /// <summary>
        /// access_token无效
        /// </summary>
        [Description("access_token无效")]
        ACCESSTOKEN_INVALID = 2190002,
        /// <summary>
        /// access_token已过期
        /// </summary>
        [Description("access_token已过期")]
        ACCESSTOKEN_EXPIERD = 2190008,
        /// <summary>
        /// 应用未获得该能力
        /// </summary>
        [Description("应用未获得该能力")]
        NONE_APP_ABILITY= 2190004
    }
}