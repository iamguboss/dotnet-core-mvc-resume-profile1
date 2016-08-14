using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller {
	public ViewResult Index() {
		return View();
	}
	[HttpPost("/result")]
	public ViewResult Result(string inputnumber,int order){
		string[] data = inputnumber.Split(',');
		double[] sumdata = data.Select(double.Parse).ToArray();
		if(order == 1){
			double sum = 0;
            for (int i = 0; i < sumdata.Length; i++)
            {
                sum = sum + sumdata[i];
            }
            sum = sum / sumdata.Length;
			ViewData["sum"] = sum;
		}
		else if(order == 2){
			double sum = 0;
            var i = 0;
            Array.Sort(sumdata);
            if (sumdata.Length % 2 == 0)
            {
                i = (sumdata.Length / 2);
                sum = (sumdata[i] + sumdata[i + 1]) / 2;
            }
            else
            {
                i = (sumdata.Length / 2);
                sum = sumdata[i];
            }
			ViewData["sum"] = sum;
		}
		else if(order == 3){
			double sum = 0;
			for(int i = 0;i < sumdata.Length;i++){
				sum += sumdata[i];
			}
			ViewData["sum"] = sum;
		}
		else{
			string msg = "มีข้อผิดพลาด";
			ViewData["sum"] = msg;
		}
		
		return View();
	}
}
