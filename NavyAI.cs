using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavyCraft
{
    // Класс компьютерного игрока
    public class NavyAI
    {
        // Поле на основании которого игрок делает ход
        private Sea targetsea;

        // Конструктор класса с передачей поля
        public NavyAI(Sea sea)
        {
            targetsea = sea;            
        }

        // Генератор случайных чисел
        private static Random rnd;

        // Создание генератора, если еще не создан
        private Random getRand() {
            if (rnd == null) rnd = new Random();
            return rnd;
        }

        // Выполнение хода
        public bool doStep() {

            // Сначала ищем, есть ли частично подбитые корабли
            for (int i=0; i<Sea.SZ; i++)
                for (int j=0; j<Sea.SZ; j++)
                    // Если поле не горит
                    if (!targetsea.isFired(i, j))
                    {
                        // Проверяем все соседние клетки, но не выходящие за рамки поля
                        // есть ли в них горящий корабль
                        bool z = false ;
                        if (i - 1 >= 0)
                            z = z || targetsea.isShipAndFired(i - 1, j);
                        if (i + 1 < Sea.SZ)
                            z = z || targetsea.isShipAndFired(i + 1, j);
                        if (j - 1 >= 0)
                            z = z || targetsea.isShipAndFired(i, j-1);
                        if (j + 1 < Sea.SZ)
                            z = z || targetsea.isShipAndFired(i, j+1);

                        // Если такое есть, то стреляем в эту клетку
                        if (z)
                        {
                            targetsea.doFire(i, j);
                            // И возвращаем, было ли подбито
                            return !targetsea.isShipAndFired(i, j);           
                        }
                    }                                            

            // и только затем стреляем наугад
            int i1 = 0 ;
            int j1 = 0 ;
            do
            {
                // Генерируем случайные числа, пока не будет выбрана еще не подбитая клетка
                i1 = getRand().Next(Sea.SZ);
                j1 = getRand().Next(Sea.SZ);
            } while (targetsea.isFired(i1, j1));

            // стреляем в эту клетку
            targetsea.doFire(i1, j1);
            // И возвращаем, было ли подбито
            return !targetsea.isShipAndFired(i1, j1);           
        }
    }
}
