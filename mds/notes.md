## [跨域访问](http://www.cnblogs.com/virtual/p/3720750.html)
> CORS: 跨域资源共享（CORS ）是一种网络浏览器的技术规范，它为Web服务器定义了一种方式，允许网页从不同的域访问其资源。而这种访问是被同源策略所禁止的。CORS系统定义了一种浏览器和服务器交互的方式来确定是否允许跨域请求。它是一个妥协，有更大的灵活性，但比起简单地允许所有这些的要求来说更加安全。 ***CORS就是为了让AJAX可以实现可控的跨域访问而生的。***

1. xxx.com 域下发起了一个跨域的POST请求，期望提交数据到api.xxx.com 这个域名的服务器，同时在提交数据的时候希望能监测到文件上传的实时进度。
2. 使用ajax准备发送post请求到'http://api.xxx.com/upload'
```
3. 浏览器自动“预发送“一个option请求，询问服务器支不支持post方法和该域名
    OPTIONS /upload HTTP/1.1
    Access-Control-Request-Method: POST
    Access-Control-Request-Headers: accept, content-type
    Origin: http://xxx.com
    -----------------------------------------------
    简而言之，OPTIONS请求方法的主要用途有两个：
    1、获取服务器支持的HTTP请求方法；
    2、用来检查服务器的性能。


```
```
4. 服务器设置接收option的请求方法，返回允许的方法和允许的域名：
    router.options('/upload', function ×(){
        this.set('Access-Control-Allow-Method', 'POST');
        this.set('Access-Control-Allow-Origin', 'http://xxx.com');
        this.status = 204;
    });
```
```
5. 浏览器得到相应，确定服务器允许http://xxx.com发送post请求，然后就发送真正的post请求：
    Access-Control-Allow-Method: POST
    Access-Control-Allow-Origin: http://xxx.com
```


## [代理服务器](https://zhidao.baidu.com/question/471701560.html)

>代理服务器作为连接Internet(广域网)与Intranet（局域网）的桥梁，负责转发合法的网络信息
>
>目的： 让局域网上不能上网的机器能够上网
####流程：

1. 局域上不能直接上网的机器将上网请求（比如说，浏览某个主页）发给能够直接上网的代理服务器
2. 然后代理服务器代理完成这个上网请求，将它所要浏览的主页调入代理服务器的缓存
3. 然后代理服务器将这个页面传给请求者
4. 达到局域网上的机器使用起来就像能够直接访问网络一样的效果

####作用
1. 代理服务器还可以进行一些网站的过滤和控制的功能，这样就实现了我们控制和节省上网费用。
2. 代理服务器能够让多台没有IP地址的电脑使用其代理功能高速、安全地访问互联网资源
3. 一般代理服务器拥有**较大的带宽，较高的性能**，并且能够智能地缓存已浏览或未浏览的网站内容
4. 常见例子：拥有上百台电脑的局域网通过一台能够访问外部网络资源的代理服务器而也能访问外部互联网。

####参考资料
* [工作原理1](https://wenku.baidu.com/view/0387037e31b765ce05081498.html)
* [工作原理2](https://wenku.baidu.com/view/1ed8e080ec3a87c24028c4de.html)
#####【Polipo资料】
* [HTTP代理polipo的配置与使用](http://wuwei5460.blog.51cto.com/2893867/1407369/)
* [官网文档1](https://www.irif.fr/~jch/software/)
* [官网文档2](https://www.irif.fr/~jch/software/polipo/)

