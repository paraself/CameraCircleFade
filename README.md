# CameraCircleFade
A simple circular wipe / fade in / fade out transition effect for Unity3D.

一个非常简单的圆形遮罩转场特效，使用Unity3D的后期特效Shader编写。

![screenshot](https://github.com/paraself/CameraCircleFade/blob/master/Example/circle2.gif)

Usage / 用法：

```c#
// in one of your monobehaviour script
// you call the instance method .FadeIn for the main camera
// the main camera will start to fade in from black to clear
// 在任意的脚本里调用任何一个相机的实例方法.FadeIn就可以把场景由全黑变成清楚的啦。
public class MyTest : Monobehaviour {
  void Start () {
    Camera.main.FadeIn(5f);
  }
}
```

or you can do these / 或者也可以这么用：

```c#
// support many easing interpolation
// 支持十几种不同的平滑插值方式
Camera.main.FadeIn(10f, Easing.Type.CubicInOut);
```

```c#
// fade out as well
Camera.main.FadeOut(5f);
```

Anyway it's just a member function for any camera, very simple!

```c#
Camera#FadeIn (float duration, Easing.Type easing);
Camera#FadeOut (float duration, Easing.Type easing);
```

------

在这个代码里，能够学到简单入门的全屏特效的写法，还有c#扩展方法的使用，还有Coroutine的用法！
