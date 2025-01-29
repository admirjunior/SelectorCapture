using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SelectorCapture
{
    public partial class Form1 : Form
    {
        private HttpListener httpListener;
        private Thread serverThread;

        public Form1()
        {
            InitializeComponent();
            StartHttpServer();
        }

        private void StartHttpServer()
        {
            serverThread = new Thread(() =>
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Add("http://localhost:5000/capture/");
                httpListener.Start();
                Console.WriteLine("Servidor rodando em http://localhost:5000/capture/");

                while (true)
                {
                    try
                    {
                        var context = httpListener.GetContext();
                        var request = context.Request;

                        if (request.HttpMethod == "OPTIONS")
                        {
                            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                            context.Response.AddHeader("Access-Control-Allow-Methods", "POST, OPTIONS");
                            context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
                            context.Response.StatusCode = 200;
                            context.Response.Close();
                            continue;
                        }

                        if (request.HttpMethod == "POST")
                        {
                            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                            {
                                string receivedData = reader.ReadToEnd();
                                Invoke(new Action(() =>
                                {
                                    txtSelector.Text = receivedData;
                                }));

                                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                                context.Response.StatusCode = 200;
                                byte[] responseBytes = Encoding.UTF8.GetBytes("Seletor recebido com sucesso!");
                                context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                                context.Response.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro no servidor: " + ex.Message);
                    }
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            httpListener?.Stop();
            serverThread?.Abort();
        }
    }
}
