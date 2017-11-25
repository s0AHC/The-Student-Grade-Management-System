﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Main
{
    public partial class StudentWin : Form
    {
        private System.Collections.Generic.List<Bunifu.Framework.UI.BunifuCustomLabel> paras;
        private BLL.StudentManager studentManager = null;
        public StudentWin(Model.User user)
        {
            this.studentManager =new BLL.StudentManager(user);
            this.paras = new List<Bunifu.Framework.UI.BunifuCustomLabel>();

            InitializeComponent();

            this.paras.Add(this.Info);
            this.paras.Add(this.Grade);
            this.paras.Add(this.course);

        }

        private void MainCloseButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BunifuCustomLabel_Enter(object sender, EventArgs e)
        {
            ((Bunifu.Framework.UI.BunifuCustomLabel)sender).ForeColor = System.Drawing.Color.FromArgb(233, 233, 234);
        }

        private void BunifuCustomLabel_Leave(object sender,EventArgs e)
        {
            ((Bunifu.Framework.UI.BunifuCustomLabel)sender).ForeColor = System.Drawing.Color.FromArgb(171, 175, 183);
        }


        /// <summary>
        /// 点击时候的样式转变
        /// </summary>
        /// <param name="sender"></param>
        private void trans_Click(object sender)
        {
            Bunifu.Framework.UI.BunifuCustomLabel Clabel = (Bunifu.Framework.UI.BunifuCustomLabel)sender;

            this.UnderLine.Location = new Point(Clabel.Location.X,
                Clabel.Location.Y + 26);
            this.UnderLine.Show();

            foreach (Bunifu.Framework.UI.BunifuCustomLabel label in paras)
            {
                label.MouseLeave -= this.BunifuCustomLabel_Leave;

                if (label != sender)
                    label.MouseLeave += this.BunifuCustomLabel_Leave;
                label.ForeColor = System.Drawing.Color.FromArgb(171, 175, 183);
            }

            Clabel.ForeColor = System.Drawing.Color.FromArgb(233, 233, 234);
        }

        private void Info_Click(object sender, EventArgs e)
        {
            if (this.UnderLine.Location.Y  != ((Bunifu.Framework.UI.BunifuCustomLabel)sender).Location.Y + 26)
            {
                this.userInfo1.Visible = false;
                this.userInfo1.BringToFront();
                this.transition1.ShowSync(this.userInfo1);
            }

            trans_Click(sender);

            Model.UserInfo userInfo = studentManager.SelectUserInfo();
            this.userInfo1.fillText(userInfo);
        }

        private void Grade_Click(object sender, EventArgs e)
        {
            if (this.UnderLine.Location.Y != ((Bunifu.Framework.UI.BunifuCustomLabel)sender).Location.Y + 26)
            {
                this.userGrade1.Visible = false;
                this.userGrade1.BringToFront();
                this.transition1.ShowSync(this.userGrade1);
            }

            trans_Click(sender);
        }

        private void course_Click(object sender, EventArgs e)
        {
            if (this.UnderLine.Location.Y != ((Bunifu.Framework.UI.BunifuCustomLabel)sender).Location.Y + 26)
            {
                this.userCourse1.Visible = false;
                this.userCourse1.BringToFront();
                this.transition1.ShowSync(this.userCourse1);
            }

            trans_Click(sender);

            Model.course course;
        }
    }
}
