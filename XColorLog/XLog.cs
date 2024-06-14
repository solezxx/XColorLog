using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace XColorLog
{
    public class XLog
    {
        public RichTextBox _richTextBox;
        public int MaxLines = 100;
        public void AddLog(string logMessage, LogLevel logLevel = LogLevel.Normal)
        {
            // 创建新的段落
            Paragraph paragraph = new Paragraph();

            // 设置文本内容和颜色
            Run run = new Run(logMessage);
            if (logLevel == LogLevel.Alarm)
            {
                run.Foreground = Brushes.Red;
            }
            else if (logLevel == LogLevel.Error)
            {
                run.Foreground = Brushes.Red;
            }
            else if (logLevel == LogLevel.Warning)
            {
                run.Foreground = Brushes.Orange;
            }
            else if (logLevel == LogLevel.Information)
            {
                run.Foreground = Brushes.Blue;
            }
            else if (logLevel == LogLevel.Debug)
            {
                run.Foreground = Brushes.Gray;
            }
            else
            {
                run.Foreground = Brushes.Black;
            }

            // 将Run添加到段落中
            paragraph.Inlines.Add(run);
            paragraph.LineHeight = 1;

            // 将段落添加到RichTextBox的文档中
            _richTextBox.Document.Blocks.Add(paragraph);
            if (_richTextBox.Document.Blocks.Count > MaxLines)
            {
                _richTextBox.Document.Blocks.Remove(_richTextBox.Document.Blocks.FirstBlock);
            }

            // 滚动到文档末尾
            _richTextBox.ScrollToEnd();
        }
    }
    public enum LogLevel
    {
        Normal,
        Warning,
        Error,
        Information,
        Debug,
        Alarm
    }
}
