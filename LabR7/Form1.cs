using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballQuiz
{
    public partial class FootballQuiz : Form
    {
        // Зберігання питання
        private List<string> questions = new List<string>()
        {
        "Який футбольний клуб найбільшу кількість разів вигравав «Лігу чемпіонів»?",
        "Який футбольний клуб вигравав найбільшу кількість разів «Кубок УЄФА»?",
        "В якому році ФК «Шахтар» (Донецьк) виграв «Кубок УЄФА»?",
        "Який футбольний клуб найбільшу кількість разів ставав чемпіоном Англії?",
        "Який футбольний клуб найбільшу кількість разів ставав чемпіоном Італії?",
        "Який футбольний клуб найбільше виграв чемпіонат Іспанії?",
        "Який футбольний клуб став першим чемпіоном України?"
    };
        // Зберігання відповідей
        private List<List<string>> answers = new List<List<string>>()
        {
            new List<string> { "Мілан", "Ліверпуль", "Реал Мадрид", "Аякс" },
            new List<string> { "Атлетіко", "Ліверпуль", "Севілья", "Ювентус" },
            new List<string> { "2007", "2009", "2010", "2008" },
            new List<string>{ "Ліверпуль", "Арсенал", "Манчестер Юнайтед", "Евертон" },
            new List<string>{ "Мілан", "Торіно", "Лаціо", "Ювентус" },
            new List<string> { "Атлетіко", "Барселона", "Реал Мадрид", "Валенсія" },
            new List<string>{ "Динамо", "Шахтар", "Таврія", "Чорноморець" }
        };
        // Індекси правильних відповідей 
        private List<int> correctAnswers = new List<int> { 2, 2, 1, 2, 2, 3, 2, 2 };

        private int currentQuestionIndex = 0;
        private int score = 0;
        public FootballQuiz()
        {
            InitializeComponent();
            LoadQuestion(); // Завантаження першого питання
            //прогрес-бар
            progressBarTest.Maximum = questions.Count;
            progressBarTest.Value = 1; // Початковий прогрес
            lblProgress.Text = $"1 з {questions.Count}";
        }
        private void LoadQuestion()
        {
            // Завантажуємо текст питання
            lblQuestion.Text = questions[currentQuestionIndex];

            // Завантажуємо варіанти відповідей
            lblOption1.Text = answers[currentQuestionIndex][0];
            lblOption2.Text = answers[currentQuestionIndex][1];
            lblOption3.Text = answers[currentQuestionIndex][2];
            lblOption4.Text = answers[currentQuestionIndex][3];
            // оновлюємо прогрес-бар
            progressBarTest.Value = currentQuestionIndex + 1;
            lblProgress.Text = $"{currentQuestionIndex + 1} з {questions.Count}";
        }
        // Перевірка, чи вибрана відповідь
        private bool IsAnswerSelected()
        {
            return rbtnOption1.Checked || rbtnOption2.Checked || rbtnOption3.Checked || rbtnOption4.Checked;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsAnswerSelected()) // Якщо вибрана відповідь
            {
                // Підраховуємо бали, перевіряючи правильність відповіді
                if (rbtnOption1.Checked && correctAnswers[currentQuestionIndex] == 0 ||
                    rbtnOption2.Checked && correctAnswers[currentQuestionIndex] == 1 ||
                    rbtnOption3.Checked && correctAnswers[currentQuestionIndex] == 2 ||
                    rbtnOption4.Checked && correctAnswers[currentQuestionIndex] == 3)
                {
                    score++; // Якщо відповідь правильна, збільшуємо бал
                }

                // Переходимо до наступного питання
                currentQuestionIndex++;

                if (currentQuestionIndex < questions.Count)
                {
                    LoadQuestion();
                }
                else
                {
                    MessageBox.Show($"Тест завершено! Ваш результат: {score} з {questions.Count}.");
                    this.Close(); // Закриваємо форму після завершення тесту
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть відповідь.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                LoadQuestion(); // Завантажуємо попереднє питання
            }
        }
    }
}
