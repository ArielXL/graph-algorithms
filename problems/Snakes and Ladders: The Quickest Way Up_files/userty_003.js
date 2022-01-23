/***************************************
* @license
* Built December 02, 17 23:37:02
* Version: 0.1.9
* Minor version: jssdk-rc-0.1.8.151
***************************************/
("undefined"!=typeof _aurycDefine?_aurycDefine:define)(["require","_auryc","aurycConfig",_aurycNormalizeUrl("core/userty.utils.js"),_aurycNormalizeUrl("core/userty.behavior.js"),_aurycNormalizeUrl("record/userty.record.js"),_aurycNormalizeUrl("feedback/userty.feedback.js")],function(e,r,aurycConfig,o,a,c,i){function d(){if(o._.console.log("check and set called"),window.aurycBehaviorAPI&&window.aurycFeedbackAPI&&window.aurycRecordAPI){o._.console.log("expose public API"),window.auryc=window.auryc||{},o.ext(window.auryc,window.aurycBehaviorAPI),o.ext(window.auryc,window.aurycFeedbackAPI),o.ext(window.auryc,window.aurycRecordAPI);var e=window.aurycReadyCb,r=window.usertyReadyCb;if(e&&e.length>0)for(var a=e.length,c=0;c<a;c++)e[c]();if(r&&o.isArr(r))for(var i=r.length,u=0;u<i;u++)r[u]()}else n>0&&(setTimeout(d,250),n--)}var n=20;r.domReady(function(){o._.console.log("api domready"),o.isProductEnabled("behavior")?d():o._.console.log("product disabled. Don't expose API")})});