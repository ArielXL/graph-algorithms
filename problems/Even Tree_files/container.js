/**
* @license
* userty JavaScript SDK v0.1.9. Saturday, December 2nd, 2017, 3:28:06 PM
* (c) Copyright 2016, userty Inc. http://www.userty.com
**/
!function(){function e(e,t){if(e){var n;for(n=0;n<e.length&&(!e[n]||!t(e[n],n,e));n+=1);}}function t(e,t){if(e){var n;for(n=e.length-1;n>-1&&(!e[n]||!t(e[n],n,e));n-=1);}}function n(e,t){return h.call(e,t)}function i(e,t){return n(e,t)&&e[t]}function r(e,t){var i;for(i in e)if(n(e,i)&&t(e[i],i))break}function o(e,t,i,a){return t&&r(t,function(t,r){!i&&n(e,r)||(!a||"object"!=typeof t||!t||y(t)||k(t)||t instanceof RegExp?e[r]=t:(e[r]||(e[r]={}),o(e[r],t,i,a)))}),e}function a(e,t){return function(){return t.apply(e,arguments)}}function s(){return v.getElementsByTagName("script")}function c(e,t){return e.getAttribute(t)}function u(e){var t,n;for(t=0;t<e.length;t++)if(n=e[t],"."===n)e.splice(t,1),t-=1;else if(".."===n){if(0===t||1==t&&".."===e[2]||".."===e[t-1])continue;t>0&&(e.splice(t-1,2),t-=2)}}if("undefined"==typeof window._aurycDefine){var f,d,l=Object.prototype,p=l.toString,h=l.hasOwnProperty,m=Array.prototype,g=window,v=document,x=m.splice,b="undefined"!=typeof opera&&"[object Opera]"===opera.toString(),y=function(e){var t=p.call(e);return"[object Array]"===t||"[object Array Iterator]"===t},E=function(e){return"string"==typeof e},k=function(e){return"function"==typeof e},M=function(e){return"undefined"!=typeof e};!function(l){function p(e){}function h(t){if(!t)return t;var n=l;return e(t.split("."),function(e){n=n[e]}),n}function m(f){function d(e,t,n){var r,o,a,s,c,f,d,l,p,h,m,g,v=t&&t.split("/"),x=J.map,b=x&&x["*"];if(e&&(e=e.split("/"),d=e.length-1,J._68&&j.test(e[d])&&(e[d]=e[d].replace(j,"")),"."===e[0].charAt(0)&&v&&(g=v.slice(0,v.length-1),e=g.concat(e)),u(e),e=e.join("/")),n&&x&&(v||b)){a=e.split("/");e:for(s=a.length;s>0;s-=1){if(f=a.slice(0,s).join("/"),v)for(c=v.length;c>0;c-=1)if(o=i(x,v.slice(0,c).join("/")),o&&(o=i(o,f))){l=o,p=s;break e}!h&&b&&i(b,f)&&(h=i(b,f),m=s)}!l&&h&&(l=h,p=m),l&&(a.splice(0,p,l),e=a.join("/"))}return r=i(J.pkgs,e),r?r:e}function m(t){e(s(),function(e){if(c(e,"data-requiremodule")===t&&c(e,"data-requirecontext")===V._43)return e.parentNode.removeChild(e),!0})}function g(e){var t=i(J.paths,e);if(t&&y(t)&&t.length>1)return t.shift(),V.require.undef(e),V._11(null,{_42:!0})([e]),!0}function v(e){var t,n=e?e.indexOf("!"):-1;return n>-1&&(t=e.substring(0,n),e=e.substring(n+1,e.length)),[t,e]}function M(e,t,n,r){var o,a,s,c,u=null,f=t?t.name:null,l=e,p=!0,h="";return e||(p=!1,e="_@r"+(ee+=1)),c=v(e),u=c[0],e=c[1],u&&(u=d(u,f,r),a=i(W,u)),e&&(u?h=a&&a._30?a._30(e,function(e){return d(e,f,r)}):e.indexOf("!")===-1?d(e,f,r):e:(h=d(e,f,r),c=v(h),u=c[0],h=c[1],n=!0,o=V._60(h))),s=!u||a||n?"":"__45"+(te+=1),{prefix:u,name:h,_52:t,_45:!!s,url:o,_40:l,isDefine:p,id:(u?u+"!"+h:h)+s}}function q(e){var t=e.id,n=i(Y,t);return n||(n=Y[t]=new V.Module(e)),n}function S(e,t,r){var o=e.id,a=i(Y,o);!n(W,o)||a&&!a._37?(a=q(e),a.error&&"error"===t?r(a.error):a.on(t,r)):"defined"===t&&r(W[o])}function w(e,t){e._50;t&&t(e)}function C(){A.length&&(x.apply(K,[K.length,0].concat(A)),A=[])}function U(e){delete Y[e],delete G[e]}function O(t,n,r){var o=t.map.id;t.error?t.emit("error",t.error):(n[o]=!0,e(t._28,function(e,o){var a=e.id,s=i(Y,a);!s||t._24[o]||r[a]||(i(n,a)?(t._85(o,W[a]),t.check()):O(s,n,r))}),r[o]=!0)}function _(){var t,n=1e3*J._41,i=n&&V.startTime+n<(new Date).getTime(),o=[],a=[],s=!1,c=!0;I||(I=!0,r(G,function(e){var n=e.map,r=n.id;if(e.enabled&&(n.isDefine||a.push(e),!e.error))if(!e._67&&i)g(r)?(t=!0,s=!0):(o.push(r),m(r));else if(!e._67&&e._65&&n.isDefine&&(s=!0,!n.prefix))return c=!1}),i&&o.length||(c&&e(a,function(e){O(e,{},{})}),i&&!t||!s||Q||(Q=setTimeout(function(){Q=0,_()},50)),I=!1))}function R(e){n(W,e[0])||q(M(e[0],null,!0)).init(e[1],e[2])}function z(e,t,n,i){e.detachEvent&&!b?i&&e.detachEvent(i,t):e.removeEventListener(n,t,!1)}function B(e){var t=e.currentTarget||e.srcElement;return z(t,V._23,"load","onreadystatechange"),z(t,V._39,"error"),{node:t,id:t&&c(t,"data-requiremodule")}}function P(){var e;for(C();K.length;){if(e=K.shift(),null===e[0])return;R(e)}}var I,F,V,$,Q,J={_41:7,baseUrl:"./",paths:{},_76:{},pkgs:{},shim:{},config:{}},Y={},G={},H={},K=[],W={},X={},Z={},ee=1,te=1;return $={require:function(e){return e.require?e.require:e.require=V._11(e.map)},exports:function(e){if(e._51=!0,e.map.isDefine)return e.exports?W[e.map.id]=e.exports:e.exports=W[e.map.id]={}},module:function(e){return e.module?e.module:e.module={id:e.map.id,uri:e.map.url,config:function(){return i(J.config,e.map.id)||{}},exports:e.exports||(e.exports={})}}},F=function(e){this.events=i(H,e.id)||{},this.map=e,this.shim=i(J.shim,e.id),this._27=[],this._28=[],this._24=[],this._46={},this._26=0},F.prototype={init:function(e,t,n,i){i=i||{},this._67||(this._31=t,n?this.on("error",n):this.events.error&&(n=a(this,function(e){this.emit("error",e)})),this._28=e&&e.slice(0),this._70=n,this._67=!0,this.ignore=i.ignore,i.enabled||this.enabled?this.enable():this.check())},_85:function(e,t){this._24[e]||(this._24[e]=!0,this._26-=1,this._27[e]=t)},fetch:function(){if(!this._65){this._65=!0,V.startTime=(new Date).getTime();var e=this.map;return this.shim?void V._11(this.map,{_25:!0})(this.shim.deps||[],a(this,function(){return e.prefix?this._48():this.load()})):e.prefix?this._48():this.load()}},load:function(){var e=this.map.url;X[e]||(X[e]=!0,V.load(this.map.id,e))},check:function(){if(this.enabled&&!this._63){var e,t,n=this.map.id,i=this._27,r=this.exports,o=this._31;if(this._67){if(this.error)this.emit("error",this.error);else if(!this._64){if(this._64=!0,this._26<1&&!this.defined){if(k(o)){if(this.events.error&&this.map.isDefine||E.onError!==p)try{r=V.execCb(n,o,i,r)}catch(a){e=a}else r=V.execCb(n,o,i,r);if(this.map.isDefine&&void 0===r&&(t=this.module,t?r=t.exports:this._51&&(r=this.exports)),e)return e._73=this.map,e._50=this.map.isDefine?[this.map.id]:null,e._74=this.map.isDefine?"define":"require",w(this.error=e)}else r=o;this.exports=r,this.map.isDefine&&!this.ignore&&(W[n]=r,E._29&&E._29(V,this.map,this._28)),U(n),this.defined=!0}this._64=!1,this.defined&&!this._72&&(this._72=!0,this.emit("defined",this.exports),this._37=!0)}}else this.fetch()}},_48:function(){var e=this.map,t=e.id,o=M(e.prefix);this._28.push(o),S(o,"defined",a(this,function(o){var s,c,u,f=i(Z,this.map.id),l=this.map.name,p=this.map._52?this.map._52.name:null,h=V._11(e._52,{_25:!0});return this.map._45?(o._30&&(l=o._30(l,function(e){return d(e,p,!0)})||""),c=M(e.prefix+"!"+l,this.map._52),S(c,"defined",a(this,function(e){this.init([],function(){return e},null,{enabled:!0,ignore:!0})})),u=i(Y,c.id),void(u&&(this._28.push(c),this.events.error&&u.on("error",a(this,function(e){this.emit("error",e)})),u.enable()))):f?(this.map.url=V._60(f),void this.load()):(s=a(this,function(e){this.init([],function(){return e},null,{enabled:!0})}),s.error=a(this,function(e){this._67=!0,this.error=e,e._50=[t],r(Y,function(e){0===e.map.id.indexOf(t+"__45")&&U(e.map.id)}),w(e)}),s.fromText=a(this,function(i,r){var o=e.name,a=M(o),c=N;r&&(i=r),c&&(N=!1),q(a),n(J.config,t)&&(J.config[o]=J.config[t]);try{E.exec(i)}catch(u){return}c&&(N=!0),this._28.push(a),V._33(o),h([o],s)}),void o.load(e.name,h,s,J))})),V.enable(o,this),this._46[o.id]=o},enable:function(){G[this.map.id]=this,this.enabled=!0,this._63=!0,e(this._28,a(this,function(e,t){var r,o,s;if("string"==typeof e){if(e=M(e,this.map.isDefine?this.map:this.map._52,!1,!this._42),this._28[t]=e,s=i($,e.id))return void(this._27[t]=s(this));this._26+=1,S(e,"defined",a(this,function(e){this._85(t,e),this.check()})),this._70&&S(e,"error",a(this,this._70))}r=e.id,o=Y[r],n($,r)||!o||o.enabled||V.enable(e,this)})),r(this._46,a(this,function(e){var t=i(Y,e.id);t&&!t.enabled&&V.enable(e,this)})),this._63=!1,this.check()},on:function(e,t){var n=this.events[e];n||(n=this.events[e]=[]),n.push(t)},emit:function(t,n){e(this.events[t],function(e){e(n)}),"error"===t&&delete this.events[t]}},V={config:J,_43:f,_87:Y,defined:W,urlFetched:X,_86:K,Module:F,_49:M,nextTick:E.nextTick,onError:w,configure:function(t){t.baseUrl&&"/"!==t.baseUrl.charAt(t.baseUrl.length-1)&&(t.baseUrl+="/");var n=J.shim,i={paths:!0,_76:!0,config:!0,map:!0};r(t,function(e,t){i[t]?(J[t]||(J[t]={}),o(J[t],e,!0,!0)):J[t]=e}),t._76&&r(t._76,function(t,n){e(t,function(e){e!==n&&(Z[e]=n)})}),t.shim&&(r(t.shim,function(e,t){y(e)&&(e={deps:e}),!e.exports&&!e.init||e._66||(e._66=V._75(e)),n[t]=e}),J.shim=n),t._47&&e(t._47,function(e){var t,n;e="string"==typeof e?{name:e}:e,n=e.name,t=e.location,t&&(J.paths[n]=e.location),J.pkgs[n]=e.name+"/"+(e.main||"main").replace(D,"").replace(j,"")}),r(Y,function(e,t){e._67||e.map._45||(e.map=M(t))}),(t.deps||t.callback)&&V.require(t.deps||[],t.callback)},_75:function(e){function t(){var t;return e.init&&(t=e.init.apply(l,arguments)),t||e.exports&&h(e.exports)}return t},_11:function(e,r){function a(t,i,o){var s,c,u;if(r._25&&i&&k(i)&&(i._88=!0),"string"==typeof t){if(k(i))return;if(e&&n($,t))return $[t](Y[e.id]);if(E.get)return E.get(V,t,e,a);if(c=M(t,e,!1,!0),s=c.id,!n(W,s))return;return W[s]}return P(),V.nextTick(function(){P(),u=q(M(null,e)),u._42=r._42,u.init(t,i,o,{enabled:!0}),_()}),a}return r=r||{},o(a,{toUrl:function(t){var n,i=t.lastIndexOf("."),r=t.split("/")[0],o="."===r||".."===r;return i!==-1&&(!o||i>1)&&(n=t.substring(i,t.length),t=t.substring(0,i)),V._60(d(t,e&&e.id,!0),n,!0)},defined:function(t){return n(W,M(t,e,!1,!0).id)},specified:function(t){return t=M(t,e,!1,!0).id,n(W,t)||n(Y,t)}}),e||(a.undef=function(n){C();var r=M(n,e,!0),o=i(Y,n);m(n),delete W[n],delete X[r.url],delete H[n],t(K,function(e,t){e[0]===n&&K.splice(t,1)}),o&&(o.events.defined&&(H[n]=o.events),U(n))}),a},enable:function(e){var t=i(Y,e.id);t&&q(e).enable()},_33:function(e){var t,r,o,a=i(J.shim,e)||{},s=a.exports;for(C();K.length;){if(r=K.shift(),null===r[0]){if(r[0]=e,t)break;t=!0}else r[0]===e&&(t=!0);R(r)}if(o=i(Y,e),!t&&!n(W,e)&&o&&!o._67){if(!(!J._61||s&&h(s)))return g(e),void 0;R([e,a.deps||[],a._66])}_()},_60:function(e,t,n){var r,o,a,s,c,u,f,d=i(J.pkgs,e);if(d&&(e=d),f=i(Z,e))return V._60(f,t,n);if(E._54.test(e))c=e+(t||"");else{for(r=J.paths,o=e.split("/"),a=o.length;a>0;a-=1)if(s=o.slice(0,a).join("/"),u=i(r,s)){y(u)&&(u=u[0]),o.splice(0,a,u);break}c=o.join("/"),c+=t||(/^data\:|\?/.test(c)||n?"":".js"),c=("/"===c.charAt(0)||c.match(/^[\w\+\.\-]+:/)?"":J.baseUrl)+c}return J._71?c+((c.indexOf("?")===-1?"?":"&")+J._71):c},load:function(e,t){E.load(V,e,t)},execCb:function(e,t,n,i){return e.indexOf("record")>=0&&"undefined"==typeof Uint8Array?{}:t.apply(i,n)},_23:function(e){if("load"===e.type||L.test((e.currentTarget||e.srcElement).readyState)){T=null;var t=B(e);V._33(t.id)}},_39:function(e){var t=B(e);!g(t.id)}},V.require=V._11(),V}function g(){return T&&"interactive"===T.readyState?T:(t(s(),function(e){if("interactive"===e.readyState)return T=e}),T)}var E,M,q,S,T,w,L="PLAYSTATION 3"===navigator.platform?/^complete$/:/^(complete|loaded)$/,U="_",O=/(\/\*([\s\S]*?)\*\/|([^:]|^)\/\/(.*)$)/gm,_=/[^.]\s*require\s*\(\s*["']([^'"\s]+)["']\s*\)/g,j=/\.js$/,D=/^\.\//,R={},z={},A=[],N=!1;E=function(e,t,n,r){var o,a,s=U;y(e)||"string"==typeof e||(a=e,y(t)?(e=t,t=n,n=r):e=[]);for(var c=0;c<e.length;c++)C[e[c]]&&(e[c]=C[e[c]]);return a&&a.context&&(s=a.context),o=i(R,s),o||(o=R[s]=E.s.newContext(s)),a&&o.configure(a),o.require(e,t,n)},E.config=function(e){return E(e)},E.nextTick="undefined"!=typeof setTimeout?function(e){setTimeout(e,4)}:function(e){e()},f=E,E._54=/^\/|:|\?|\.js$/,M=E.s={contexts:R,newContext:m},E({}),e(["toUrl","undef","defined","specified"],function(e){E[e]=function(){var t=R[U];return t.require[e].apply(t,arguments)}}),q=M.head=v.getElementsByTagName("head")[0],S=v.getElementsByTagName("base")[0],S&&(q=M.head=S.parentNode),E.onError=p,E.createNode=function(e,t,n){var i=e.xhtml?v.createElementNS("http://www.w3.org/1999/xhtml","html:script"):v.createElement("script");return e.scriptType&&(i.type=e.scriptType),i.setAttribute("data-cfasync",!1),i.charset="utf-8",i.async=!0,i},E.load=function(e,t,n){var i,r=e&&e.config||{};return i=E.createNode(r,t,n),i.setAttribute("data-requirecontext",e._43),i.setAttribute("data-requiremodule",t),!i.attachEvent||i.attachEvent.toString&&i.attachEvent.toString().indexOf("[native code")<0||b?(i.addEventListener("load",e._23,!1),i.addEventListener("error",e._39,!1)):(N=!0,i.attachEvent("onreadystatechange",e._23)),i.src=n,w=i,S?q.insertBefore(i,S):q.appendChild(i),w=null,i},d=function(e,t,n){var i,r;"string"!=typeof e&&(n=t,t=e,e=null),y(t)||(n=t,t=null),!t&&k(n)&&(t=[],n.length&&(n.toString().replace(O,"").replace(_,function(e,n){t.push(n)}),t=(1===n.length?["require"]:["require","exports","module"]).concat(t))),N&&(i=w||g(),i&&(e||(e=c(i,"data-requiremodule")),r=R[c(i,"data-requirecontext")])),(r?r._86:A).push([e,t,n])},E.exec=function(e){return new Function(e)()},E(z)}(this),g._aurycDefine=d,g._aurycRequire=f;var aurycCmd=function(e){var t=(window.location.hash+"").toLowerCase(),n="auryccommand";return e=(e||"").toLowerCase(),t.length>2&&t.indexOf(n)>-1&&t.indexOf(e)>-1};aurycCmd();var AurycProductConfig={}; 
      /**
    * Defines the container product
    */
    AurycProductConfig.container = ({
  "check": function () {
    if (!window.JSON) {
      return false;
    }

    // new configuration objects
    var baseConfig = {overWritten: false};
    var recordConfig = {overWritten: false};
    var feedbackConfig = {overWritten: false};
    var ruleengineConfig = {overWritten: false};
    var behaviorConfig = {overWritten: false};

    baseConfig={"enabled": true,"siteid": "235-hackerrankcomcommunity","siteToken": "6469d95c06c6ab3c425447b35f9dd90d"};
feedbackConfig={"siteid":"235-hackerrankcomcommunity","instances":[]};
recordConfig={"enabled":true,"throttles":{"sampling":100},"filters":{},"layout":"CENTERFIXED","exclude":{"urls":[],"referrers":[],"userAgents":[],"browsers":[],"cookies":[],"variables":[]},"browser_cutoff":{"IE":9,"Safari":5.1,"Firefox":11,"Chrome":20,"Chrome Mobile":20,"Opera":1000},"platform_cutoff":{"Android":4.1,"Winphone":8,"iPod":7,"iPhone":7,"iPad":7},"device_type_support":{"desktop":true,"phone":true,"tablet":true},"device_blacklist":["HTC_Rezound","blackberry"],"pii":{"staticBlockEls":{},"dynamicBlockEls":{},"staticVisibleEls":{},"dynamicVisibleEls":{},"assetBlockEls":{},"removeVisibilityEls":{},"obscureEls":{}},"svgCaptureEnabled":false,"scrollEls":null,"regexScrub":[],"watchNodeList":"","shortenedDomRewrites":false,"keepComments":false,"keepInputs":false,"useEleMutation":false,"saved":"true","disabled":false};
ruleengineConfig={"siteid":"235-hackerrankcomcommunity","creatives":[{"id":1,"template":"signup","display":{"color":"#ffffff"},"content":{"img":"https://s3.amazonaws.com/public-assets.auryc.com/creatives/test/teec.png"},"triggers":{"serialized":"f.pv > 2 and f.pageload"},"goal":{"event":"click","target":"#goal1"}},{"id":2,"template":"fblike","display":{"color":"#ffffff"},"content":{"img":"https://s3.amazonaws.com/public-assets.auryc.com/creatives/test/fblike_teec.jpg"},"triggers":{"serialized":"f.pv > 2 and f.halfwaydown and f.url = 'teammember' "},"goal":{"event":"click","target":"#goal1"}}]};
behaviorConfig={"enabled":true,"siteid":"235-hackerrankcomcommunity","autotracking":true,"sessionDuration":1800,"trackingMode":"new","sampling":5};
    // IMPORTANT: add any additional config below

    baseConfig.enabled = true;
    baseConfig.code_version = "0.1.9";
    baseConfig.device_uri = "uba-detector.userty.com/useragent";
    baseConfig.services_url = "https://services.auryc.com";
    baseConfig.tracking_uri = "uba-tracking.userty.com";
    baseConfig.uba_api_uri = "uba-api.auryc.com";
    baseConfig.token_uri = "services.auryc.com/cc-services/sites";
    baseConfig.auto_tracking_uri = "uba-tracking.auryc.com";
    baseConfig.DEBUG = false;
    recordConfig.record_uri = "https://uba-tracking.auryc.com/rec/";

    feedbackConfig.enabled = true;
    // for legacy compatibility
    var ubtCfg = (behaviorConfig.overWritten === false) ? {enabled: true} : behaviorConfig;

    var aurycConfig = {
      base: baseConfig,
      feedback: feedbackConfig,
      record: recordConfig,
      ruleengine: ruleengineConfig,
      behavior: ubtCfg
    };

    _aurycDefine('aurycConfig', function () {
      return aurycConfig;
    });

    return true;
  },

  "dependencies": (function(w) {

    /**
     *
     * @param cfgObj the product specific config object
     * @param globalOverride the global override. used in testings
     * @returns {*}
     */
    var isEnabled = function(cfgObj, hashOverride) {
      var prodEnabled = (cfgObj && cfgObj.enabled);
      return prodEnabled || (hashOverride && aurycCmd(hashOverride));
    };

    // new configuration objects
    var recordConfig = {};
    var feedbackConfig = {};
    var ruleengineConfig = {};

    baseConfig={"enabled": true,"siteid": "235-hackerrankcomcommunity","siteToken": "6469d95c06c6ab3c425447b35f9dd90d"};
feedbackConfig={"siteid":"235-hackerrankcomcommunity","instances":[]};
recordConfig={"enabled":true,"throttles":{"sampling":100},"filters":{},"layout":"CENTERFIXED","exclude":{"urls":[],"referrers":[],"userAgents":[],"browsers":[],"cookies":[],"variables":[]},"browser_cutoff":{"IE":9,"Safari":5.1,"Firefox":11,"Chrome":20,"Chrome Mobile":20,"Opera":1000},"platform_cutoff":{"Android":4.1,"Winphone":8,"iPod":7,"iPhone":7,"iPad":7},"device_type_support":{"desktop":true,"phone":true,"tablet":true},"device_blacklist":["HTC_Rezound","blackberry"],"pii":{"staticBlockEls":{},"dynamicBlockEls":{},"staticVisibleEls":{},"dynamicVisibleEls":{},"assetBlockEls":{},"removeVisibilityEls":{},"obscureEls":{}},"svgCaptureEnabled":false,"scrollEls":null,"regexScrub":[],"watchNodeList":"","shortenedDomRewrites":false,"keepComments":false,"keepInputs":false,"useEleMutation":false,"saved":"true","disabled":false};
ruleengineConfig={"siteid":"235-hackerrankcomcommunity","creatives":[{"id":1,"template":"signup","display":{"color":"#ffffff"},"content":{"img":"https://s3.amazonaws.com/public-assets.auryc.com/creatives/test/teec.png"},"triggers":{"serialized":"f.pv > 2 and f.pageload"},"goal":{"event":"click","target":"#goal1"}},{"id":2,"template":"fblike","display":{"color":"#ffffff"},"content":{"img":"https://s3.amazonaws.com/public-assets.auryc.com/creatives/test/fblike_teec.jpg"},"triggers":{"serialized":"f.pv > 2 and f.halfwaydown and f.url = 'teammember' "},"goal":{"event":"click","target":"#goal1"}}]};
behaviorConfig={"enabled":true,"siteid":"235-hackerrankcomcommunity","autotracking":true,"sessionDuration":1800,"trackingMode":"new","sampling":5};
    feedbackConfig.enabled = true;
    var baseDeps = [];
    //feedbackConfig is available through CONFIG_GOES_HERE, always enable feedback
    if (aurycCmd('feedbackpreview')
        || isEnabled(feedbackConfig, 'aurycFeedback')) { // config is the old config object for feedback
      if (w.aurycContainerMode === 'standalone') { // used in standalone feedback such as email
        baseDeps.push("feedback/userty.feedbacksurvey.js");
      } else {
        baseDeps.push("feedback/userty.feedback.js");
      }
    }

    if (isEnabled(ruleengineConfig, 'aurycRuleEngine')) {
      baseDeps.push("ruleengine/userty.ruleengine.js")
    }

    if (isEnabled(recordConfig, 'aurycRecord')) {
      baseDeps.push("record/userty.record.js")
    }

    baseDeps.push("visualEditorLoader/userty.visualeditorloader.js")
    baseDeps.push("core/userty.api.js")

    return baseDeps;
  })(window)

})
;
 
AurycProductConfig.__auryc__=!0;var q={loadScript:function(e,t){var n=document.createElement("script");n.setAttribute("data-cfasync",!1),n.charset="UTF-8",n.src=e,t&&(n.onload=t);var i=document.getElementsByTagName("script");i.length>0?i[0].parentNode.insertBefore(n,i[0]):document.head.appendChild(n)}};q.loadConfig=function(){try{q.loadScript(T._89("ec.js")),q.loadScript(T._89("ef.js"))}catch(e){console.log("failed to load config"),console.log(e)}};var S=function(e){function t(e){p=1;do e=i.shift(),e&&e();while(e)}var n,i=[],r=!1,o=document,a=o.documentElement,s=a.doScroll,c="DOMContentLoaded",u="addEventListener",f="onreadystatechange",d="readyState",l=s?/^loaded|^c/:/^loaded|c/,p=l.test(o[d]);return o[u]&&o[u](c,n=function(){o.removeEventListener(c,n,r),t()},r),s&&o.attachEvent(f,n=function(){/^c/.test(o[d])&&(o.detachEvent(f,n),t())}),e=s?function(t){self!=top?p?t():i.push(t):function(){try{a.doScroll("left")}catch(n){return setTimeout(function(){e(t)},50)}t()}()}:function(e){try{p?e():i.push(e)}catch(t){}}}(),T={_84:window._aurycVOverride?window._aurycVOverride:"0.1.9",containerLocation:function(){var t,n,i,r=s(),o="container",a="/";if(e(r,function(e){i=c(e,"src")||"","userty"==c(e,"data-vendor")&&c(e,"data-role")==o?t=e:i.indexOf(o)>-1&&(n=e)}),t||(t=n),t)return i=c(t,"src"),i.indexOf(":/")==-1&&i.substr(0,1)!=a&&(r=g.location.href.toString().split(a),r[r.length-1].indexOf(".")>-1&&r[r.length-1].toLowerCase()!=g.location.hostname.toLowerCase()&&r.pop(),i=r.join(a)+(i.substr(0,1)==a?"":a)+i),i=i.split(a),i.pop(),u(i),i.join(a)+a}()};T.isProduction=T.containerLocation.toLowerCase().indexOf("production")>-1,T._89=function(e,t){return e=e||"",function(n){n=n||"/";"v="+encodeURIComponent(T._84);return n.indexOf("//")==-1&&(n="/"==e.substr(e.length-1,1)&&"/"==n.substr(0,1)?e+n.substr(1):e+n),n+(n.indexOf("?")>-1?"&":"?")+"v="+encodeURIComponent(t)}}(T.containerLocation,T._84),g._aurycNormalizeUrl=T._89;var w=[],C={};r(AurycProductConfig,function(e,t){if(e.check===!0||k(e.check)&&e.check.call(e)){var n=e.dependencies,i=e.equivalencies;w=w.concat(E(n)?[n]:n),i&&r(i,function(e,t){C[t]=e})}}),r(C,function(t,n){var i=!1;e(w,function(e,n){w[n]==t&&(i=!0)}),i||delete C[n]}),e(w,function(e,t){w[t]=T._89(e)});var L,U=[],O="aurycReady",_=!1,j=function(){S(function(){clearTimeout(L),L=setTimeout(function(){for(;U.length>0;)U.pop().call()},250)})},D=window["__"+O+"__"]=function(){for(var e=0;e<arguments.length;e++)k(arguments[e])&&U.push(arguments[e]);_&&j()};M(g[O])||(g[O]=D);var R=g.performance&&g.performance.timing?g.performance.timing.responseStart:(new Date).getTime();d("_auryc",function(){return{home:T.containerLocation,allReady:D,domReady:S,containerConfig:AurycProductConfig,makeURI:T._89,startTS:R,isProduction:T.isProduction}}),q.loadConfig(),f(w,function(){_=!0,j()})}}();
