using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SelemiumWebDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var mensagem = "AQUI VAI A SUA MENSAGEM";

            string[] grupos = {"AQUI VAI OS GRUPOS"};

            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://web.whatsapp.com/");

            Thread.Sleep(25000);//Esse time aqui é para dar tempo de ler o QRcode do Whatsapp
            
            for(int i = 0; i <= grupos.Length; i++)
            {
                //<span dir="auto" title="Notas" class="emoji-texttt _ccCW FqYAR i0jNr">Notas</span>
                driver.FindElement(By.XPath($"//span[@title='{grupos[i]}']")).Click();

                //<div tabindex="-1" class="p3_M1 _1YbbN">
                driver.FindElement(By.ClassName("p3_M1")).SendKeys(mensagem);
                Thread.Sleep(1000);

                //<span data-testid="send" data-icon="send" class="">
                driver.FindElement(By.XPath("//span[@data-testid='send']")).Click();
            }
        }
    }
}
