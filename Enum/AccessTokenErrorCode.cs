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
        /// client_key 错误
        /// </summary>
        [Description("client_key 错误")]
        CONFIGURATION_INVALID = 10003,
        /// <summary>
        /// 应用权限不足，请申请对应的 scope 权限
        /// </summary>
        [Description("应用权限不足，请申请对应的 scope 权限")]
        NO_PERMISSIONS = 10004,
        /// <summary>
        /// 缺少参数
        /// </summary>
        [Description("缺少参数")]
        MISSING_PARAMETER = 10005,
        /// <summary>
        /// 非法重定向 URI，需要与 app 配置中的"授权回调域"一致
        /// </summary>
        [Description("非法重定向 URI，需要与 app 配置中的 授权回调域 一致")]
        ILLEGAL_REDIRECT_URI = 10006,
        /// <summary>
        /// 授权码过期
        /// </summary>
        [Description("授权码过期")]
        ACCESS_TOKEN_CODE_EXPIRED = 10007,
        /// <summary>
        /// access_token 无效或过期
        /// </summary>
        [Description("access_token 无效或过期")]
        ACCESS_TOKEN_EXPIRED = 10008,
        /// <summary>
        /// refresh_token 过期
        /// </summary>
        [Description("refresh_token 过期")]
        REFRESH_TOKEN_EXPIRED = 10010,
        /// <summary>
        /// 应用包名与配置不一致
        /// </summary>
        [Description("应用包名与配置不一致")]
        APPLICTAION_PACKAGE_CONFIGURATION = 10011,
        /// <summary>
        /// 应用正在审核中，无法进行授权
        /// </summary>
        [Description("应用正在审核中，无法进行授权")]
        APP_REVIEW = 10012,
        /// <summary>
        /// client_key 或者 client_secret 报错
        /// </summary>
        [Description("client_key 或者 client_secret 报错")]
        KEY_SECRET_ERROR = 10013,
        /// <summary>
        /// 授权的 client_key 与获取 access_token 时传递的 client_key 不一致
        /// </summary>
        [Description("授权的 client_key 与获取 access_token 时传递的 client_key 不一致")]
        KEY_ERROR = 10014,
        /// <summary>
        /// 应用类型错误，如将 app 应用的 client_key 用于 PC 应用
        /// </summary>
        [Description("应用类型错误，如将 app 应用的 client_key 用于 PC 应用")]
        APPLICATION_TYPE_ERROR = 10015,
        /// <summary>
        /// 安卓应用签名与配置不一致，请检查签名信息
        /// </summary>
        [Description("安卓应用签名与配置不一致，请检查签名信息")]
        ANDROID_APPLICATION_SIGNATURE_INVALID = 10017,
        /// <summary>
        /// 更新 refresh_token 次数超出限制
        /// </summary>
        [Description("更新 refresh_token 次数超出限制")]
        REFRESH_TOKEN_LIMIT = 10020,
        /// <summary>
        /// 命中敏感词
        /// </summary>
        [Description("命中敏感词")]
        HIT_SENSITIVE_WORDS = 2111001,
        /// <summary>
        /// 获取评论失败
        /// </summary>
        [Description("获取评论失败")]
        GET_COMMENTS_FAILED = 2111002,
        /// <summary>
        /// 无效的评论
        /// </summary>
        [Description("无效的评论")]
        COMMENT_INVAILD = 2111003,
        /// <summary>
        /// 非本视频评论
        /// </summary>
        [Description("非本视频评论")]
        NON_VIDEO_COMMENTS = 2111004,
        /// <summary>
        /// 上一个置顶评论正在审核中, 请稍后再试
        /// </summary>
        [Description("上一个置顶评论正在审核中, 请稍后再试")]
        PREVIOUS_TOP_COMMENT_REVIEW = 2111005,
        /// <summary>
        /// 评论失败
        /// </summary>
        [Description("评论失败")]
        COMMENT_FAILED = 2111006,
        /// <summary>
        /// 获取视频失败
        /// </summary>
        [Description("获取视频失败")]
        GET_VIDEO_FAILED = 2111007,
        /// <summary>
        /// 非企业号用户
        /// </summary>
        [Description("非企业号用户")]
        NON_ENTERPRISE_ACCOUNT_USER = 2112001,
        /// <summary>
        /// 素材不符合要求, 未通过审核
        /// </summary>
        [Description("素材不符合要求, 未通过审核")]
        MATERIAL_DOES_NOT_REQUIREMENTS_AND_NOT_PASSED = 2113001,
        /// <summary>
        /// 您的素材数量已达上限
        /// </summary>
        [Description("您的素材数量已达上限")]
        MATERIAL_QUANTITY_LIMIT = 2113002,
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
        /// 系统繁忙，此时请开发者稍候再试
        /// </summary>
        [Description("系统繁忙，此时请开发者稍候再试")]
        SYSTEM_BUSY = 2100004,
        /// <summary>
        /// 参数不合法
        /// </summary>
        [Description("参数不合法")]
        PARAMETER_INVALID = 2100005,
        /// <summary>
        /// open_id 与 follower_open_id 相同
        /// </summary>
        [Description("open_id 与 follower_open_id 相同")]
        PARAMETER_SAME_OPENID_FOLLOWER_OPENID = 2100006,
        /// <summary>
        /// 无权限操作
        /// </summary>
        [Description("无权限操作")]
        NONE_PERMISSIONS = 2100007,
        /// <summary>
        /// 用户被禁封使用该操作
        /// </summary>
        [Description("用户被禁封使用该操作")]
        OPERATION_BANNED = 2100009,
        /// <summary>
        /// 请求参数 access_token openid 不匹配
        /// </summary>
        [Description("请求参数 access_token openid 不匹配")]
        PARAMETER_MISMATCHING_ACCESSTOKEN_OPENID = 2190015,
        /// <summary>
        /// quota已用完
        /// </summary>
        [Description("quota已用完")]
        QUOTA_OVER = 2190001,
        /// <summary>
        /// access_token无效
        /// </summary>
        [Description("access_token无效")]
        ACCESSTOKEN_INVALID = 2190002,
        /// <summary>
        /// 用户未授权该
        /// </summary>
        [Description("用户未授权该 API")]
        NOT_AUTHORIZED_API = 2190003,
        /// <summary>
        /// 应用未获得该能力
        /// </summary>
        [Description("应用未获得该能力")]
        NONE_APP_ABILITY = 2190004,
        /// <summary>
        /// 视频文件太大了
        /// </summary>
        [Description("视频文件太大了")]
        VIDEO_FILE_TOO_LARGE = 2190005,
        /// <summary>
        /// 视频时长不能超过 15 分钟
        /// </summary>
        [Description("视频时长不能超过 15 分钟")]
        VIDEO_DURATION_EXCEED_15_MINUTES = 2190006,
        /// <summary>
        /// 无效的视频文件 ID
        /// </summary>
        [Description("无效的视频文件 ID")]
        VIDEO_ID_INVALID = 2190007,
        /// <summary>
        /// access_token 过期,请刷新或重新授权
        /// </summary>
        [Description("access_token 过期,请刷新或重新授权")]
        ACCESSTOKEN_EXPIERD = 2190008,
    }
}