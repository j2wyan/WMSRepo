using GrapeCity.Win.MultiRow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS_V1.BL
{
  public  class FunctionKeyAction  : IAction 
    {
        private Keys m_KeyCode = Keys.None;


        public FunctionKeyAction(Keys keyCode)
        {
            this.m_KeyCode = keyCode;
        }

        public bool CanExecute(GcMultiRow target)
        {
            return true;
        }

        public string DisplayName
        {
            get { return this.ToString(); }
        }

        public void Execute(GcMultiRow target)
        {
            try
            {

                JutyuEntry denpyo = (JutyuEntry)target.Parent.TopLevelControl;
                denpyo.GridEvent(this.m_KeyCode, target.Name);
            }
            catch (Exception ex)
            { }
        }

        public Keys KeyCode
        {
            get { return m_KeyCode; }
            set { m_KeyCode = value; }
        }
    }
}
