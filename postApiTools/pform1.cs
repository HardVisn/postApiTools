﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace postApiTools
{
    public class pform1
    {
        //------------------------ini-------------------------------------------------
        /// <summary>
        /// http类型写入
        /// </summary>
        /// <param name="comboBox"></param>
        public static void httpTypeWrite(ComboBox comboBox)
        {
            lib.pIni ini = new lib.pIni(Config.configIni);
            ini.IniWriteValue("form1", "httpTypeWrite", comboBox.Text);
        }

        /// <summary>
        /// http类型读取
        /// </summary>
        /// <param name="comboBox"></param>
        public static void httpTypeWriteRead(ComboBox comboBox)
        {
            lib.pIni ini = new lib.pIni(Config.configIni);
            try { comboBox.Text = ini.IniReadValue("form1", "httpTypeWrite"); } catch { comboBox.Text = "GET"; }

        }
        /// <summary>
        /// 写入httpHTML类型
        /// </summary>
        /// <param name="comboBox"></param>
        public static void httpHtmlTypeDataWrite(ComboBox comboBox)
        {
            lib.pIni ini = new lib.pIni(Config.configIni);
            ini.IniWriteValue("form1", "httpHtmlTypeDataWrite", comboBox.Text);
        }
        /// <summary>
        /// 读取httpHTML类型进行覆盖
        /// </summary>
        /// <param name="comboBox"></param>
        public static void httpHtmlTypeDataRead(ComboBox comboBox)
        {
            lib.pIni ini = new lib.pIni(Config.configIni);
            try { comboBox.Text = ini.IniReadValue("form1", "httpHtmlTypeDataWrite"); } catch { comboBox.Text = "TEXT"; }

        }

        /// <summary>
        /// textboxurl 写
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="url"></param>
        public static void textBoxUrlWrite(TextBox textbox, string url)
        {
            lib.pIni ini = new lib.pIni(Config.configIni);
            textbox.Text = url;
            ini.IniWriteValue("form1", "textboxurl", url);
        }
        /// <summary>
        /// textboxurl 读
        /// </summary>
        /// <param name="textbox"></param>
        public static void textBoxUrlRead(TextBox textbox)
        {
            string url = "";
            lib.pIni ini = new lib.pIni(Config.configIni);
            try
            {
                url = ini.IniReadValue("form1", "textboxurl");
            }
            catch
            {
            }
            textbox.Text = url;
        }
        //------------------------ini-------------------------------------------------


        /// <summary>
        /// 显示运行时间和状态
        /// </summary>
        /// <param name="code"></param>
        /// <param name="runtime"></param>
        /// <param name="codeStr"></param>
        /// <param name="runStr"></param>
        public static void labelShowStatusRunTime(Label code, Label runtime, string codeStr, string runStr)
        {
            code.Text = codeStr;
            runtime.Text = runStr + "ms";
        }


        /// <summary>
        /// dataview转object
        /// </summary>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static object dataViewToObjectArray(DataGridView dd)
        {
            int row = dd.RowCount - 1;
            object[,] array = new object[row, 3];
            for (int i = 0; i < row; i++)
            {
                if (dd.Rows[i].Cells[0].Value != null)
                {
                    //list.Add(dd.Rows[i].Cells[0].Value.ToString());
                    array[i, 0] = dd.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    //list.Add("");
                    array[i, 0] = "";
                }

                if (dd.Rows[i].Cells[1].Value != null)
                {
                    //list.Add(dd.Rows[i].Cells[1].Value.ToString());
                    array[i, 1] = dd.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    //list.Add("");
                    array[i, 1] = "";
                }

                if (dd.Rows[i].Cells[2].Value != null)
                {
                    //list.Add(dd.Rows[i].Cells[2].Value.ToString());
                    array[i, 2] = dd.Rows[i].Cells[2].Value.ToString();
                }
                else
                {
                    //list.Add("");
                    array[i, 2] = "";
                }
            }
            return array;
        }


        /// <summary>
        /// dataview dataurl 转 多维数组
        /// </summary>
        /// <param name="dd"></param>
        /// <returns></returns>
        public static string[,] dataViewUrlDataToObjectArray(DataGridView dd)
        {
            int row = dd.RowCount - 1;
            string[,] array = new string[row, 3];
            for (int i = 0; i < row; i++)
            {
                if (dd.Rows[i].Cells[0].Value != null)
                {
                    //list.Add(dd.Rows[i].Cells[0].Value.ToString());
                    array[i, 0] = dd.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    //list.Add("");
                    array[i, 0] = "";
                }

                if (dd.Rows[i].Cells[1].Value != null)
                {
                    //list.Add(dd.Rows[i].Cells[1].Value.ToString());
                    array[i, 1] = dd.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    //list.Add("");
                    array[i, 1] = "";
                }

                if (dd.Rows[i].Cells[2].Value != null)
                {
                    //list.Add(dd.Rows[i].Cells[2].Value.ToString());
                    array[i, 2] = dd.Rows[i].Cells[2].Value.ToString();
                }
                else
                {
                    //list.Add("");
                    array[i, 2] = "";
                }
            }
            return array;
        }


        /// <summary>
        /// dataview生成对象转urldata
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string objectArrayToUrlData(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            string urlData = "";
            object[,] array = (object[,])obj;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i < array.GetLength(0) - 1)
                {
                    urlData += array[i, 0] + "=" + array[i, 1] + "&";
                }
                else
                {
                    urlData += array[i, 0] + "=" + array[i, 1];
                }
            }

            return urlData;
        }

        /// <summary>
        /// 输出报文头
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="data"></param>
        public static void dataViewResponseShow(DataGridView dd, string[,] data = null)
        {
            if (data == null)
            {
                data = lib.phttp.Get_HttpCustom_Response_Headers();
                if (data == null)
                {
                    return;
                }
            }
            dd.Invalidate();
            dd.Rows.Clear();//清理行数
            dd.Rows.Add(data.GetLength(0));
            for (int i = 0; i < data.GetLength(0); i++)
            {
                dd.Rows[i].Cells[0].Value = data[i, 0];
                dd.Rows[i].Cells[1].Value = data[i, 1];
                dd.Rows[i].Cells[2].Value = "";
            }
        }

        /// <summary>
        /// 浏览器显示本地HTML
        /// </summary>
        /// <param name="w"></param>
        /// <param name="html"></param>
        public static void webViewShow(WebBrowser w, string html)
        {
            string path = Config.exePath + "/runtime/";
            if (!Directory.Exists(path))//判断文件夹是否存在
            {
                Directory.CreateDirectory(path);
            }
            string pathHtml = path + lib.pBase.CreateMD5Hash(DateTime.Now.ToLocalTime().ToString()) + ".html";
            lib.pFile.Write(pathHtml, html);
            w.ScriptErrorsSuppressed = true;
            w.Url = new Uri(pathHtml);
        }
        //---------------------------------------------------------------------------------------------------------------
        //public static string HtmlToFormat()
        //{
        //}
        //---------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------template---------------------------------------------------
        /// <summary>
        /// 输出生成模板
        /// </summary>
        /// <param name="textHtml"></param>
        /// <param name="textDoc"></param>
        /// <param name="combobox"></param>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <param name="urldata"></param>
        /// <param name="html"></param>
        /// <param name="url"></param>
        public static void createTemplateString(TextBox textHtml, TextBox textDoc, ComboBox combobox, string name, string method, string[,] urldata, string html, string url)
        {

            switch (combobox.Text)
            {
                case "默认模板":
                    textDoc.Text = templateString(Config.exePath + "/data/template.txt", name, method, urldata, html, url);
                    break;
            }
        }
        /// <summary>
        /// 返回生成文档内容
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <param name="urldata"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string templateString(string path, string name, string method, string[,] urldata, string html, string url)
        {
            string urldataStr = "";
            for (int i = 0; i < urldata.GetLength(0); i++)
            {
                urldataStr += "|" + urldata[i, 0] + "|" + "是 |" + "" + urldata[i, 1] + "" + "|" + urldata[i, 2] + "|";
            }
            string template = lib.pFile.Read(path);
            template = template.Replace("{$name}", name);
            template = template.Replace("{$method}", method);
            template = template.Replace("{$urldata}", urldataStr);
            template = template.Replace("{$url}", url);
            template = template.Replace("{$html}", html);
            return template;
        }
        //----------------------------------------------------template---------------------------------------------------
    }
}
