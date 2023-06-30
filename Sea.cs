using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NavyCraft
{
    // Поле игры
    public class Sea
    {
        // Размер
        public static int SZ = 10;
        // Метка игрока
        public static string SHIPM="X" ;
        // Число промахов
        public int misscount = 0;

        // Массив кораблей
        private bool[,] ship;
        // Массив открытых клеток
        private bool[,] fired;

        // Конструктор, создаем двумерные массивы поля и подбитых клеток
        public Sea()
        {
            ship = new bool[SZ, SZ];
            fired = new bool[SZ, SZ];
            for (int i=0; i<SZ; i++)
                for (int j=0; j<SZ; j++) {
                    ship[i,j]=false ;
                    fired[i,j]=false ;
                }
        }

        // Начальная расстановка кораблей
        public void setRandomShip()
        {
            new SeaFiller().copyToArray(ship);
        }
        
        // Возврат, открыта ли клетка
        public bool isFired(int i, int j)
        {
            return fired[i, j];
        }

        // Получить метку поля - для своих, видим корабли, для чужих, только если открыто
        public string getMark(int i, int j, bool mysea)
        {
            if (mysea) return ship[i, j] ? SHIPM : ""; // если поле человека-игрока (наше) видим корабли
            else {
                if (fired[i, j]) return ship[i, j] ? SHIPM : ""; else return ""; // если поле чужое, видим корабли, если открыты
            }            
        }

        // Находит ли по адресу - подбитый корабль
        public bool isShipAndFired(int i, int j)
        {
            return ship[i, j] && fired[i, j];
        }

        // Выстрел в клетку
        public bool doFire(int i, int j)
        {
            // Если клетка еще не подбита
            if (!fired[i, j])
            {
                fired[i, j] = true;
                // Если попали в корабль, открываем угловые клетки
                if (ship[i, j])
                {
                    // Но только те клетки, которые не за пределами поля
                    if ((i - 1 >= 0) && (j - 1 >= 0)) fired[i - 1, j - 1] = true;
                    if ((i - 1 >= 0) && (j + 1 < SZ)) fired[i - 1, j + 1] = true;
                    if ((i + 1 < SZ) && (j - 1 >= 0)) fired[i + 1, j - 1] = true;
                    if ((i + 1 < SZ) && (j + 1 < SZ)) fired[i + 1, j + 1] = true;

                    // Составляем массив точек корабля, в который попали
                    var tekship = new List<Point>(); // упорядоченная пару целых чисел — координат Х и Y
                    tekship.Add(new Point(i, j));

                    // движение вверх, вниз, влево, вправо
                    var dx = new int[] { -1, 0, 1, 0 };
                    var dy = new int[] { 0, -1, 0, 1 };

                    // Для всех четырех направлений движений, добавляем клетки, если они принадлежат кораблю
                    for (int d = 0; d < 4; d++)
                    {
                        int sx = i + dx[d];
                        int sy = j + dy[d];
                        while (!((sx < 0) || (sx >= SZ) || (sy < 0) || (sy >= SZ))) // пределы карты
                        {
                            if (ship[sx, sy]) tekship.Add(new Point(sx, sy)); else break;
                            sx += dx[d];
                            sy += dy[d];
                        }
                    }

                    // Если корабль подбили (все клетки корабля попали),                     
                    int cnt = 0;
                    foreach (var p in tekship)
                        if (fired[p.X, p.Y]) cnt++;
                    // то открываем и все остальные клетки рядом
                    if (cnt == tekship.Count)
                    {
                        foreach (var p in tekship)
                        {
                            // Для всех направлений
                            for (int d = 0; d < 4; d++)
                            {
                                int sx = p.X + dx[d];
                                int sy = p.Y + dy[d];
                                // Но только в пределах поля
                                if (!((sx < 0) || (sx >= SZ) || (sy < 0) || (sy >= SZ)))
                                    fired[sx, sy] = true;
                            }
                        }
                    }
                }
                else
                    // Иначе увеличиваем число промахов
                    misscount++;
                return true;
            }
            else
                return false;
        }

        // Проверка, все ли корабли подбиты
        public bool isTotalKilled()
        {
            int cnt = 0 ; // счетчик кораблей
            int cntkilled = 0 ; // счетчик подбитых кораблей
            for (int i=0; i<SZ; i++)
                for (int j = 0; j < SZ; j++) {
                    if (ship[i, j])
                    {
                        // Увеличиваем счетчик кораблей и подбитых кораблей
                        cnt++;
                        if (fired[i, j]) cntkilled++;
                    }
                }
            // Если счетчики совпали
            return cnt == cntkilled;
        }

        // Число промахов
        public int getMissCount()
        {
            return misscount;
        }

        // Число попаданий
        public int getHitCount()
        {
            int cnt = 0;
            for (int i = 0; i < SZ; i++)
                for (int j = 0; j < SZ; j++)
                    // Попадание - это клетка подбитая для корабля
                    if (fired[i, j] && ship[i, j]) cnt++;
            return cnt;
        }
    }
}
