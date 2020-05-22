using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeOnWinForms
{
    public partial class Form1 : Form
    {
        private int _width =860;  //размеры нашего окна 860
        private int _height = 860; //860
        private int _fieldSize = 40; //размер сетки(квадратика)
        private int _dirX, _dirY; //передвижение змейки


        //Создание фрукта
        private PictureBox _fruit = new PictureBox();
        private int _randomFruitX, _randomFruitY;

        //создадим массив для змеи, при поедании фруктов
        private PictureBox[] snake = new PictureBox[250];
        private int _score = 0;
        private Label labelScore = new Label(); //счетчик

        //Уровень сложности 
        private ComboBox chooseLevel = new ComboBox();
        public Form1()
        {
            InitializeComponent();

            //передвижение змейки
            this.KeyDown += new KeyEventHandler(OKP); //обработчик нажатия кнопок с клавиатуры
            _mapGenerating(); //генерация карты через pictureBox
            this.Width = _width;
            this.Height = _height;
            _dirX = 1;
            _dirY = 0;

            //скорость передвижения змейки
            timer.Tick += new EventHandler(_update);
            timer.Interval = 250; //скорость перемещения змейки, который будет запускаться _update
            timer.Start();

            //фрукты
            _fruit = new PictureBox();
            _fruit.BackColor = Color.Yellow;
            _fruit.Size = new Size(_fieldSize, _fieldSize);
            _generateFruit();

            //поедание фруктов
            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 200); //начальная позиция змейки
            snake[0].Size = new Size(_fieldSize, _fieldSize); //его размер
            snake[0].BackColor = Color.Green;
            this.Controls.Add(snake[0]);

            //Счетчик
            labelScore.Text = "Счет: 0";
            labelScore.Location = new Point(801, 25); //расположение нашего счетчика
            this.Controls.Add(labelScore); //добавляем в нашу форму

            //Выбор уровеня сложности
            chooseLevel.Text = "Выберите сложность...";
            chooseLevel.Items.Add("Легко");
            chooseLevel.Items.Add("Средне");
            chooseLevel.Items.Add("Хардкор");
            chooseLevel.Size = new Size(150, 150);
            chooseLevel.Location = new Point(802, 5);
           // this.Controls.Add(chooseLevel);

        }


//----------------------------------------------------Методы---------------------------------------------------------------
       private void OKP(object sender, KeyEventArgs e) //выводит нажатые клавиши (передвижение змеи)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up":
                    // snakeBox.Location = new Point(snakeBox.Location.X, snakeBox.Location.Y - _fieldSize);
                    _dirY = -1;
                    _dirX = 0;
                    break;
                case "Down":
                    //  snakeBox.Location = new Point(snakeBox.Location.X, snakeBox.Location.Y + _fieldSize);
                    _dirY = 1;
                    _dirX = 0;
                    break;
                case "Left":
                    // snakeBox.Location = new Point(snakeBox.Location.X - _fieldSize, snakeBox.Location.Y);
                    _dirX = -1;
                    _dirY = 0;
                    break;
                case "Right":
                    // snakeBox.Location = new Point(snakeBox.Location.X + _fieldSize, snakeBox.Location.Y);
                    _dirX = 1;
                    _dirY = 0;
                    break;
            }            
        }
        private void _update(object myObject, EventArgs eventArgs) //вызовы методов
        {
            _snakeMove(); //вызов метода в другом методе
            _fruitEat();
            _eatSnake();
            _borderExit();
         //   _chooseYourLevel();
            //поставить snakeBox в Visible = false иначе будет задвоение змейки
            //  snakeBox.Location = new Point(snakeBox.Location.X + _dirX * _fieldSize, snakeBox.Location.Y + _dirY * _fieldSize);
        }

        //будем вызывать этот метод в update
        private void _snakeMove() //измененная система движения змеи (движение всей структуры нашей змеи)
        {
            for (int i = _score; i >= 1; i--)  
            {
                //перемещаем значение квадратика на нужную нам 1(единицу)
                snake[i].Location = snake[i - 1].Location; 
            }
            //для гибкости змеи
            snake[0].Location = new Point(snake[0].Location.X + _dirX * _fieldSize, snake[0].Location.Y + _dirY * _fieldSize); 
        }

        private void _mapGenerating()  //Создание карты через PictureBox
       {
            for(int x = 0; x < _width / _fieldSize; x++) //горизонтальные линии
            {
                PictureBox pictureLineX = new PictureBox();
                pictureLineX.BackColor = Color.Black;
                pictureLineX.Location = new Point(0, _fieldSize * x); //начало расположении линии 0 и до размера ширины поля
                pictureLineX.Size = new Size(_width - 59, 1); //длина линии и его толщина (1) -300
                this.Controls.Add(pictureLineX); //добавление поля в окно
            }
            for (int y = 0; y < _height / _fieldSize; y++) //вертикальные линии
            {
                PictureBox pictureLineY = new PictureBox();
                pictureLineY.BackColor = Color.Black;
                pictureLineY.Location = new Point(_fieldSize * y, 0);
                pictureLineY.Size = new Size(1, _height - 59); //-59 подобрал значения вручную, чтобы не вылезало за края
                this.Controls.Add(pictureLineY);                //-100
            }

        }

        private void _generateFruit() //метод для генерации фрукта
        {
            Random rand = new Random();
            _randomFruitX = rand.Next(0, (_height-59) - _fieldSize); //генерация значения от 0 до нашей ширины
            int tempX = _randomFruitX % _fieldSize; //чтобы получить размеры кратные 40
            _randomFruitX -= tempX; //полученный остаток от деления и вычитаем из полученной переменной

            _randomFruitY = rand.Next(0, (_height-59) - _fieldSize);
            int tempY = _randomFruitY % _fieldSize;
            _randomFruitY -= tempY;
            _fruit.Location = new Point(_randomFruitX, _randomFruitY); //на выходе переменные кратные 40 будут
            this.Controls.Add(_fruit);
        }

        private void _fruitEat() //поедание фруктов
        {
            if (snake[0].Location.X == _randomFruitX && snake[0].Location.Y == _randomFruitY) //сравнение координат змеи и фрукта
            {
                labelScore.Text = "Счет: " + ++_score; //увеличение счета
                snake[_score] = new PictureBox(); //добавление нового элемента (нового квадрата)
                snake[_score].Location = new Point(snake[_score - 1].Location.X + 40 * _dirX, snake[_score - 1].Location.Y - 40 * _dirY);
                snake[_score].Size = new Size(_fieldSize, _fieldSize); //координаты предыдущего кубика: score - 1
                snake[_score].BackColor = Color.Green; //уменьшаем размер нашего кубика _fieldSize - 1, чтобы не выходил за границы квадратика
                this.Controls.Add(snake[_score]);
               
                _generateFruit();  //генерация нового фрукта, после взятия прошлого
            }
        }

        private void _eatSnake() //поедание себя
        {
            for (int tail = 1; tail < _score; tail++)
            {
                //проверка координат головного кубика с другими кубиками змейки
                if(snake[0].Location == snake[tail].Location)
                {
                    //отнимаем кубик, произошло столкновение
                    for (int j = tail; j <= _score; j++)
                    {
                        this.Controls.Remove(snake[j]);                       
                    }
                    _score = _score - (_score - tail + 1); 
                }
            }
        }

        
        private void _borderExit() //выход за карту
        {
            if(snake[0].Location.X < 0) 
            {
                for(int i = 1; i <= _score; i++)
                {
                    this.Controls.Remove(snake[i]); //удаление кубиков
                }
                _score = 0; //обнуление очков
                labelScore.Text = "Счет: " + _score;
                _dirX = 1; //изменение направление при выходе за карту по оси Х
            }

            if (snake[0].Location.X > _height)
            {
                for (int i = 1; i <= _score; i++)
                {
                    this.Controls.Remove(snake[i]); //удаление кубиков
                }
                _score = 0; //обнуление очков
                labelScore.Text = "Счет: " + _score;
                _dirX = -1;
            }

            if (snake[0].Location.Y < 0) //изменение направление при выходе за карту по оси Х
            {
                for (int i = 1; i <= _score; i++)
                {
                    this.Controls.Remove(snake[i]); //удаление кубиков
                }
                _score = 0; //обнуление очков
                labelScore.Text = "Счет: " + _score;
                _dirY = 1;
            }

            if (snake[0].Location.Y > _height)
            {
                for (int i = 1; i <= _score; i++)
                {
                    this.Controls.Remove(snake[i]); //удаление кубиков
                }
                _score = 0; //обнуление очков
                labelScore.Text = "Счет: " + _score;
                _dirY = -1;
            }
        }

        //private void _chooseYourLevel() //Выбор уровня сложности 
        //{
        //    switch (chooseLevel.SelectedItem)
        //    {
        //        case "Легкий":
        //            timer.Interval = 500;
        //            timer.Start();
        //            break;

        //        case "Средний":
        //            timer.Interval = 250;
        //            timer.Start();
        //            break;

        //        case "Хардкор":
        //            timer.Interval = 100;
        //            timer.Start();
        //            break;

        //        default:
        //            timer.Interval = 500;
        //            break;
        //    }
        //}
    }
}
