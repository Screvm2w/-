using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavyCraft
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        // Игровые поля
        private Sea mysea;
        private Sea compsea;
        // Контроллеры
        private Sea2Grid sgmy;
        private Sea2Grid sgcomp;

        // Алгоритм компьютерного противника
        private NavyAI ai;

        private bool mystep = true;
        private bool gameover = false;

        // Таймер эмуляции хода противника (выдержать паузу для наглядности)
        private Timer compstep;

        // Обновление интерфейса игры
        private void UpdateUI()
        {
            // Если не конец игры, вывод ходов
            if (!gameover)
            {
                labStep.Text = (mystep ? "Ваш ход" : "Ход противника");
                labStep.BackColor = (mystep ? Color.Green : Color.Red);
            }
            else
            {
                // Иначе вывод победы
                labStep.Text = mystep ? "Победа игрока" : "Победа компьютера";                  
                labStep.BackColor = (mystep ? Color.Green : Color.Red);
            }
            labStep.ForeColor = Color.White;
            // Установка разрешения на огонь
            sgcomp.fireenabled = mystep && (!gameover);
            labMyInfo.Text = String.Format("Попаданий: {0}, промахов: {1}", mysea.getHitCount(), mysea.getMissCount());
            labCompInfo.Text = String.Format("Попаданий: {0}, промахов: {1}", compsea.getHitCount(), compsea.getMissCount());
            // Процент попадания у Игрока
            if(compsea.getHitCount() > 0 || compsea.getMissCount() > 0)
            {
                //MessageBox.Show(Convert.ToString((double)((double)compsea.getHitCount() / (double)(compsea.getHitCount() + compsea.getMissCount())) * 100));
                LabCompFired.Text = String.Format("Процент попаданий игрока:{0} %", (double)((double)compsea.getHitCount() / (double)(compsea.getHitCount() + compsea.getMissCount())) * 100);
                LabFiredAI.Text = String.Format("Процент попаданий AI:{0} %", (double)((double)mysea.getHitCount() / (double)(mysea.getHitCount() + mysea.getMissCount())) * 100);
            }
            
        }
        // Следующий ход с параметром, меняем ли игрока
        private void NextStep(bool switchplayer)
        {
            // Проверка окончания игры
            if (mystep)
            {
                // Для компьютера
                if (compsea.isTotalKilled())
                {
                    gameover = true;
                    UpdateUI();
                    return;
                }
            }
            else
            {
                // Для игрока
                if (mysea.isTotalKilled())
                {
                    gameover = true;
                    UpdateUI();
                    return;
                }            
            }

            // Переключение игрока
            if (switchplayer)
            {
                mystep = !mystep;
            }

            // Если ход компьютера, то запуск его таймера
            if (!mystep)
            {
                compstep.Start();
            }

            UpdateUI();
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            // Отвязывание старых событий
            if (sgmy != null) sgmy.RemoveEvents();
            if (sgcomp != null) sgcomp.RemoveEvents();

            // Создание и заполнение полей
            mysea = new Sea();
            mysea.setRandomShip();

            compsea = new Sea();
            compsea.setRandomShip();
                        
            // Создание событийных контроллеров
            sgmy = new Sea2Grid(dgvmy, mysea,true);
            sgcomp = new Sea2Grid(dgvcomp, compsea, false);
            sgmy.doExport();
            sgcomp.doExport();
            // Установка события - завершение хода
            sgcomp.setNextProc(NextStep);

            // Создание игрока компьютера
            ai = new NavyAI(mysea);

            // Ход игрока, сброс конца игры
            mystep = true;
            gameover = false;
            UpdateUI();
        }

        private void dgvcomp_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Создание таймера компьютерного игока
            compstep = new Timer();
            compstep.Interval = 1000;
            compstep.Tick += new System.EventHandler(compstep_Tick);
        }

        // Событие сбарабывает для хода компьютерного игрока
        private void compstep_Tick(object sender, EventArgs e)
        {
            // Таймер игрока компьютера - стоп
            compstep.Stop();

            // Делаем ход компьютеров
            NextStep(ai.doStep());
            
            // Обновляем контроллер
            sgmy.doExport();                    
            
        }

        private void dgvmy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
