# CallYourName

只是一个点名器罢了。
我也不是真的特有闲心在高三搞这个。只不过是班里一个老师恰好要用罢了。

一开始很短，后来自己竟然造起了大轮子——我给这个玩意儿写了个动画库。
其实也不是最近才写的，动画库的念想一年前就有了。但是因为我当初门路不对，竟然用起了Timer——这就是自虐。Timer每一次事件都会新开一个线程，结果我被多如牛毛的线程搞的一团糟，而且还涉及到公共资源原子操作的问题。当时是放弃了。
前一阵子在图书馆翻到了写游戏引擎的书，稍微有了一点灵感。于是趁着这个机会完成了。
不过就算有了方向，也不是很顺利。昨天和今天我照样遇见了各种各样匪夷所思的bug。debug心累。

反正最后能用了。而且也可以轻松扩充，只不过我懒得写文档，也没时间和心情写。

动画库就是那个Animation文件夹下的东西。目前为止还是一维的水平，但是扩充到二维我觉得很简单。


