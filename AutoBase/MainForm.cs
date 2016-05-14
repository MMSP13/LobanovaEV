using AutoBase.Model;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBase
{
    public partial class MainForm : Form
    {
        const int cBook = 4;
        const int cArticle = 3;

        private Configuration myConfig;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            mySessionFactory = DBService.Factory;
            mySession = mySessionFactory.OpenSession();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySession.Close();
        }
        private void Add(Entity Object)//добавить
        {
            using (mySession.BeginTransaction())
            {
                mySession.Save(Object);
                mySession.Transaction.Commit();
                mySession.Flush();
            }
        }
        private void btnArticleList_Click(object sender, EventArgs e)
        {
            try
            {
                using (mySession.BeginTransaction())
                {
                    ICriteria myCriteria = mySession.CreateCriteria<Article>();
                    IList<Article> list = myCriteria.List<Article>();
                    mySession.Transaction.Commit();
                    mySession.Flush();
                    dgvData.ColumnCount = cArticle;
                    int n = list.Count;
                    dgvData.RowCount = n;
                    dgvData.Columns[0].Name = "Автор";
                    dgvData.Columns[1].Name = "Контакты";
                    dgvData.Columns[2].Name = "Тема";
                    dgvData.AutoResizeColumnHeadersHeight();
                    dgvData.AutoResizeColumns();
                    for (int i = 0; i < n; i++)
                    {
                        dgvData[0, i].Value = list[i].Author;
                        dgvData[1, i].Value = list[i].Email;
                        dgvData[2, i].Value = list[i].TemaArticle;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListBook_Click(object sender, EventArgs e)
        {
            try
            {
                using (mySession.BeginTransaction())
                {
                    ICriteria myCriteria = mySession.CreateCriteria<Book>();
                    IList<Book> list = myCriteria.List<Book>();
                    mySession.Transaction.Commit();
                    mySession.Flush();
                    dgvData.ColumnCount = cBook;
                    int n = list.Count;
                    dgvData.RowCount = n;
                    dgvData.Columns[0].Name = "Гл Редактор";
                    dgvData.Columns[1].Name = "Телефон";
                    dgvData.Columns[2].Name = "База";
                    dgvData.Columns[3].Name = "Журнал";
                    dgvData.AutoResizeColumnHeadersHeight();
                    dgvData.AutoResizeColumns();
                    for (int i=0; i < n; i++)
                    {
                        dgvData[0, i].Value = list[i].NameRED;
                        dgvData[1, i].Value = list[i].Tel;
                        dgvData[2, i].Value = list[i].IndexBase;
                        dgvData[3, i].Value = list[i].Jornal;
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AutoBase.Model.Book SendingBook = new AutoBase.Model.Book { NameRED = "Редактор1", Tel = "999999999", IndexBase = "База", Jornal = "Журнал" };
                AutoBase.Model.Article SendingArticle = new AutoBase.Model.Article { Author = "Автор1", Email = "кекпаоа", TemaArticle = "1254876312", idBook = SendingBook };
                Add(SendingBook);
                Add(SendingArticle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void button2_Click(object sender, EventArgs e)
         {

         }
    }
}
