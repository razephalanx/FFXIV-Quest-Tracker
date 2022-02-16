using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIV_Quest_Tracker
{
    partial class AboutBoxFFXIVQT : Form
    {
        public AboutBoxFFXIVQT()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelAuthors.Text = "by " + AssemblyCompany;

            #region Plain text description content
            /* Kept as a backup in case RTF version proves unstable/unreliable
            this.richTextBoxDescription.Text =  "A simple, lightweight program for keeping track of complete and incomplete quests in Final Fantasy XIV.\n\n" +
                                                "Github page:  https://github.com/razephalanx/FFXIV-Quest-Tracker\n" +
                                                "_____________________________________________________________________________________\n\n" +
                                                "Garland Tools was created and is maintained by Clorifex Ezalor of Zalera\n" +
                                                "Garland Tools Website:  https://www.garlandtools.org/\n" +
                                                "Garland Tools Discord:  https://discord.gg/hfzmApj\n" +
                                                "_____________________________________________________________________________________\n\n" +
                                                "FINAL FANTASY is a registered trademark of Square Enix Holdings Co., Ltd.\n" +
                                                "FINAL FANTASY XIV © SQUARE ENIX CO., LTD.";
            //*/
            #endregion

            #region RTF description contents
            //* Kinda messy in code, but ends up a bit nicer looking than plain text
            this.richTextBoxDescription.Rtf = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
{\colortbl ;\red0\green0\blue255;\red5\green99\blue193;}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\widctlpar\sa160\sl252\slmult1\f0\fs18 A simple, lightweight program for keeping track of complete and incomplete quests in Final Fantasy XIV.\par
{{\field{\*\fldinst{HYPERLINK " + "\"https://github.com/razephalanx/FFXIV-Quest-Tracker\"" + @" }}{\fldrslt{\ul\cf1\cf2\ul Github Page}}}}\f0\fs18\par
{\pict{\*\picprop}\wmetafile8\picw1764\pich882\picwgoal9361\pichgoal30
0100090000038c01000007001c00000000000400000003010800050000000b0200000000050000
000c023300420f040000002e0118001c000000fb021000000000000000bc020000000001020222
53797374656d0000000000000000000000000000000000000000000000000000040000002d0100
001c000000fb021000070000000000bc02000000000102022253797374656d000db3010000f0a2
96f3fa7f0000ac15ef6e9f00000020000000040000002d01010004000000f0010000040000002d
010100040000002d0101001c000000fb021000000000000000bc02000000000102022253797374
656d0000000000000000000000000000000000000000000000000000040000002d010000040000
002d01010004000000f00100001c000000fb021000000000000000bc0200000000010202225379
7374656d0000000000000000000000000000000000000000000000000000040000002d01000004
0000002d01010004000000f00100001c000000fb021000000000000000bc020000000001020222
53797374656d0000000000000000000000000000000000000000000000000000040000002d0100
00040000002d01010004000000f001000004000000020101001c000000fb02a4ff000000000000
9001000000000440002243616c6962726900000000000000000000000000000000000000000000
000000040000002d010000040000002d010000040000002d010000050000000902000000020d00
0000320a5700000001000400000000003c0f32002000360005000000090200000002030000001e
0007000000fc020000a0a0a0000000040000002d01020008000000fa02050000000000ffffff00
040000002d0103000e00000024030500ffffffffffff32003c0f32003c0fffffffffffff080000
00fa0200000000000000000000040000002d01040007000000fc020000ffffff00000004000000
2d010500040000002701ffff1c000000fb021000070000000000bc020000000001020222417269
616c000000000000000000000000000000000000000000000000000000040000002d0106000400
00002d010600030000000000
}\par
Garland Tools was created and is maintained by Clorifex Ezalor of Zalera.\par
{{\field{\*\fldinst{HYPERLINK " + "\"https://www.garlandtools.org/\"" + @" }}{\fldrslt{\ul\cf1\cf2\ul Garland Tools Website}}}}\f0\fs18\par
{{\field{\*\fldinst{HYPERLINK " + "\"https://discord.gg/hfzmApj\"" + @" }}{\fldrslt{\ul\cf1\cf2\ul Garland Tools Discord}}}}\f0\fs18\par
{\pict{\*\picprop}\wmetafile8\picw1764\pich882\picwgoal9361\pichgoal30
0100090000038c01000007001c00000000000400000003010800050000000b0200000000050000
000c023300420f040000002e0118001c000000fb021000000000000000bc020000000001020222
53797374656d0000000000000000000000000000000000000000000000000000040000002d0100
001c000000fb021000070000000000bc02000000000102022253797374656d000db3010000f0a2
96f3fa7f0000ac15ef6e9f00000020000000040000002d01010004000000f0010000040000002d
010100040000002d0101001c000000fb021000000000000000bc02000000000102022253797374
656d0000000000000000000000000000000000000000000000000000040000002d010000040000
002d01010004000000f00100001c000000fb021000000000000000bc0200000000010202225379
7374656d0000000000000000000000000000000000000000000000000000040000002d01000004
0000002d01010004000000f00100001c000000fb021000000000000000bc020000000001020222
53797374656d0000000000000000000000000000000000000000000000000000040000002d0100
00040000002d01010004000000f001000004000000020101001c000000fb02a4ff000000000000
9001000000000440002243616c6962726900000000000000000000000000000000000000000000
000000040000002d010000040000002d010000040000002d010000050000000902000000020d00
0000320a5700000001000400000000003c0f32002000360005000000090200000002030000001e
0007000000fc020000a0a0a0000000040000002d01020008000000fa02050000000000ffffff00
040000002d0103000e00000024030500ffffffffffff32003c0f32003c0fffffffffffff080000
00fa0200000000000000000000040000002d01040007000000fc020000ffffff00000004000000
2d010500040000002701ffff1c000000fb021000070000000000bc020000000001020222417269
616c000000000000000000000000000000000000000000000000000000040000002d0106000400
00002d010600030000000000
}\par
FINAL FANTASY is a registered trademark of Square Enix Holdings Co., Ltd.\par
FINAL FANTASY XIV \'a9 SQUARE ENIX CO., LTD.\lang9\par
}";
            //*/
            #endregion
        }

        // Open link clicked in richTextBoxDescription in browser
        private void richTextBoxDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.LinkText) { UseShellExecute = true });
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
