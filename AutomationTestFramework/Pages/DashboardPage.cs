using AutomationTestFramework.Selenium;
using OpenQA.Selenium;
using System;

namespace AutomationTestFramework.Pages
{
    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                var headerContent = Driver.Instance.FindElement(By.ClassName("masterbar__item-content"));
                ObjectDump.Write(Console.Out, headerContent);
                return headerContent.Text == "My Site";
            }
        }
    }
}
