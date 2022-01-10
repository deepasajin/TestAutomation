using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Outlook= Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
using WiniumPOC.Utilities;
using System.IO;

namespace WiniumPOC.CommonFunctions
{
	public class EmailNotification
	{


		public void SendEmail(string mailToRecipients, string mailCCRecipients, string subjectLine, [Optional] string attachments, string HTMLBody)
		{

			try
			{
				//// Create the Outlook application object.
				Outlook.Application oApp = new Outlook.Application();

				////Create the new message.
				Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);

				//Add a recipient.
				// TODO: Change the following recipient where appropriate.
				Outlook.Recipients oRecips = oMsg.Recipients;
				List<string> oTORecip = new List<string>();
				List<string> oCCRecip = new List<string>();

				var ToRecip = mailToRecipients.Split(',');
				var CCRecip = mailCCRecipients.Split(',');


				foreach (string ToRecipient in ToRecip)
				{
					oTORecip.Add(ToRecipient);
				}

				foreach (string CCRecipient in CCRecip)
				{
					oCCRecip.Add(CCRecipient);
				}

				foreach (string to in oTORecip)
				{
					Outlook.Recipient oTORecipt = oRecips.Add(to);
					oTORecipt.Type = (int)Outlook.OlMailRecipientType.olTo;
					oTORecipt.Resolve();
				}

				foreach (string cc in oCCRecip)
				{
					Outlook.Recipient oCCRecipt = oRecips.Add(cc);
					oCCRecipt.Type = (int)Outlook.OlMailRecipientType.olCC;
					oCCRecipt.Resolve();
				}

				//Set the basic properties.
				oMsg.Subject = subjectLine;
				if (attachments.Length > 0)
				{

					//Add an attachments.
					string sDisplayName = "ExecutionResult_" + GenericMethods.DateandTimeToString();
					int iPosition = 1;
					int iAttachType = (int)Outlook.OlAttachmentType.olByValue;

					//Select the latest file from Directory
					var reportDirectory = new DirectoryInfo("C:\\Temp\\Reports\\TestRun");
					var latestTestReport = (from file in reportDirectory.GetFiles() orderby file.LastAccessTimeUtc descending select file).First().ToString();
					var attachmentFile = "C:\\Temp\\Reports\\TestRun\\" + latestTestReport;
					Outlook.Attachment oAttach = oMsg.Attachments.Add(attachmentFile, iAttachType, iPosition, sDisplayName);
				}

				if (HTMLBody.Length > 0)
				{
					oMsg.HTMLBody = HTMLBody;
				}

				//Send the message.
				oMsg.Save();
				oMsg.Send();
				new ReportHelper().WriteLog("Pass", "Email with execution result sent successfully!!");

				//Explicitly release objects.
				oTORecip = null;
				oCCRecip = null;
				oMsg = null;
				oApp = null;
			}
			catch(Exception e)
			{
				new ReportHelper().WriteLog("Fail", "Email with execution result couldnot be send due to : " + e.Message);
			}

		}


	}
}
