using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager_SOFT130
{

    class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.Olive; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.Black; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.Black; }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.Black;
            }
        }
    }
}
