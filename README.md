# DisabledCursor
提供禁用状态下的鼠标样式控制
<h2>示例代码</h2>
<pre>
    &lt;Window x:Class="WpfApp.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            mc:Ignorable="d"
            xmlns:lib="http://lan.design.com"
            Title="MainWindow" Height="450" Width="800">
        &lt;Grid>
            &lt;Button lib:Assists.UseDisabledDesign="True" Content="禁用" IsEnabled="False" Height="30" Width="100">&lt;/Button>
        &lt;/Grid>
    &lt;/Window>
</pre>
