using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using YHCSK;

namespace WMS_V1
{
    public class SdkCallback //: YHCSK.CYayoiHanbaiCommonSdkCallback
    {
        public void ErrorInfo(string ErrorMessage)
        {
            //FormDialog.ResultLog.Items.Add(ErrorMessage);
            // FormDialog.label6.Text = ErrorMessage;
           // MessageBox.Show(ErrorMessage);
        }

        public void ExecuteErrorInfo(string ErrorMessage)
        {
            //FormDialog.ResultLog.Items.Add(ErrorMessage);
            //FormDialog.label6.Text = ErrorMessage;
           // MessageBox.Show(ErrorMessage);
        }

        public void ImportErrorInfo(int ErrorLine, int ErrorCol, string ErrorItem, string ErrorMessage)
        {
            //FormDialog.ResultLog.Items.Add(ErrorMessage);
            // FormDialog.label6.Text = ErrorMessage;
           // MessageBox.Show("Line:" + ErrorLine + "///Col:" + ErrorCol + "///Message:" + ErrorMessage);
        }

        public void DempyoImportInfo1(System.DateTime DempyoDate, int DempyoBango, int DempyoId, bool bResult)
        {
            if (bResult == true)
            {
                //FormDialog.ResultLog.Items.Add(string.Format("伝票を登録しました 伝票日付={0} 伝票番号={1} 伝票ID={2}", DempyoDate, DempyoBango, DempyoId));
                // FormDialog.label6.Text = string.Format("伝票を登録しました 伝票日付={0} 伝票番号={1} 伝票ID={2}", DempyoDate, DempyoBango, DempyoId);
                //FormDialog.label6.Text = string.Format("伝票を登録しました 伝票日付={0}", DempyoDate);

            }
            else
            {
                //FormDialog.ResultLog.Items.Add(string.Format("伝票の登録に失敗しました 伝票日付={0} 伝票番号={1}", DempyoDate, DempyoBango));
                // FormDialog.label6.Text = string.Format("伝票の登録に失敗しました 伝票日付={0} 伝票番号={1}", DempyoDate, DempyoBango);
                //FormDialog.label6.Text = string.Format("伝票の登録に失敗しました 伝票日付={0} ", DempyoDate);
               // MessageBox.Show(string.Format("伝票を登録しました 伝票日付={0} 伝票番号={1} 伝票ID={2}", DempyoDate, DempyoBango, DempyoId));
            }
        }
        //void YHCSK.IYayoiHanbaiCommonSdkCallback.DempyoImportInfo(System.DateTime DempyoDate, int DempyoBango, int DempyoId, bool bResult)
        //{
        //    DempyoImportInfo1(DempyoDate, DempyoBango, DempyoId, bResult);
        //}

        //public void SetForm(OrderCreate Form)
        //{
        //    FormDialog = Form;
        //}
    }
}
