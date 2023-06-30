using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NavyCraft
{
    // Контроллер вывода и обработки поля в таблицу
    public class Sea2Grid
    {
        // Ссылка на сетку для вывода
        private DataGridView _grid;
        // Ссылка на поле
        private Sea _sea;
        // Поле человека-игрока?
        private bool mysea;

        // Разрешен ли выстрел кликом
        public bool fireenabled;

        // Делегат следующего хода
        public delegate void ProcNext(bool changeplayer);
        private ProcNext procNext;
        
        public void setNextProc(ProcNext proc)
        {
            procNext = proc;
        }

        // Ссылки на события - формат и нажатия мыши
        private DataGridViewCellFormattingEventHandler eventFormat;
        private DataGridViewCellEventHandler eventClick;

        // Конструктор получает сетку, поле и признак, чье это поле
        public Sea2Grid(DataGridView grid, Sea sea, bool Amysea)
        {
            _grid = grid;
            _sea = sea;
            mysea = Amysea;

            // Создаем события и привязываем в интерфейс
            eventFormat = new System.Windows.Forms.DataGridViewCellFormattingEventHandler(grid_CellFormatting);
            eventClick = new System.Windows.Forms.DataGridViewCellEventHandler(grid_CellClick);

            _grid.CellFormatting += eventFormat;
            // Клик разрешен только для чужого поля
            if (!mysea) _grid.CellDoubleClick += eventClick;
        }

        // Удаляем события
        public void RemoveEvents() {
            _grid.CellFormatting -= eventFormat;
            if (!mysea) _grid.CellDoubleClick -= eventClick;
        }

        // Вывод поля в таблицу
        public void doExport()
        {
            // Сначала создаем строк и столбцы, если ранее не создали
            if (_grid.Columns.Count != Sea.SZ)
            {
                _grid.Rows.Clear();
                _grid.Columns.Clear();

                for (int j = 0; j < Sea.SZ; j++)
                {
                    _grid.Columns.Add(new DataGridViewTextBoxColumn()); // тип класса, используемый DataGridViewColumn для логического размещения ячеек, которые позволяют отображать и редактировать текстовые строки
                    _grid.Columns[j].HeaderCell.Value = Convert.ToChar(65+j).ToString(); // преобразование значений символы юникода (А, B, C...)                 
                    _grid.Columns[j].Width = 24; // ширина столбца в точках
                }

                _grid.RowHeadersWidth = 50; // ширина столбца в пикселях, содержащая заголовки строк
                for (int i = 0; i < Sea.SZ; i++)
                {
                    _grid.Rows.Add();
                    _grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

            }

            // Выводим метки в ячейки
            for (int i = 0; i < Sea.SZ; i++)
                for (int j = 0; j < Sea.SZ; j++)
                    _grid.Rows[i].Cells[j].Value = _sea.getMark(i, j, mysea);
            _grid.Refresh();
            _grid.ClearSelection();
                        
        }

        // Формат поля - цвет для подбитых
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int i = e.RowIndex;
            int j = e.ColumnIndex;
            if (_sea.isFired(i, j)) e.CellStyle.BackColor = Color.FromArgb(105, 105, 105); // DimGrey
        }

        // Обработка щелчка
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Если клик не разрешен
            if (!fireenabled) return;

            int i = e.RowIndex;
            int j = e.ColumnIndex;
            // Если выстрел успешен, то обновляем поле
            if (_sea.doFire(i, j))
            {
                doExport();  
                // Возврат смены игрока, если не был подбит корабль
                procNext(!_sea.isShipAndFired(i,j));
            }
        }

    }
}
