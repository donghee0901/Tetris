using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Form1 : Form
    {
        const int Block_count = 7;

        static int score = 0;

        static int block_x;
        static int block_y;
        static int block_spin;
        static int block_kinds;

        static int next_block_kinds;
        static int next_block_spin;

        static int save_block_kinds = -1;
        static int save_block_spin = -1;

        static Color[] block_color = new Color[Block_count] { Color.Orange, Color.Blue, Color.Purple, Color.Yellow, Color.SkyBlue, Color.Red, Color.Green };
        static int[,] Map = new int[22, 12]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1 }
            };
        static int[,,,] block = new int[Block_count, 4, 4, 4]
        {
            {
                {
                    {0,0,0,0},
                    {0,1,1,1},
                    {0,1,0,0},
                    {0,0,0,0}
                },
                {
                    {0,0,0,0},
                    {0,1,1,0},
                    {0,0,1,0},
                    {0,0,1,0}
                },
                {
                    {0,0,0,0},
                    {0,0,1,0},
                    {1,1,1,0},
                    {0,0,0,0}
                },
                {
                    {0,1,0,0},
                    {0,1,0,0},
                    {0,1,1,0},
                    {0,0,0,0}
                },
            },
            {
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 1},
                    {0, 0, 0, 0}
                },
                {
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                },
                {
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 0}
                },
                {
                    {0, 0, 1, 0},
                    {0, 0, 1, 0},
                    {0, 1, 1, 0},
                    {0, 0, 0, 0}
                }
            },
            {
        {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 1},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 1, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 1, 1},
                {0, 0, 1, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 0},
        },
},
            {
        {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
        },
},
            {
        {
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0},
        },
        {
                {0, 0, 0, 0},
                {1, 1, 1, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 0},
        },
        {
                {0, 0, 0, 0},
                {1, 1, 1, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
        },
},
            {
        {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 1},
                {0, 0, 1, 1},
                {0, 0, 1, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 1},
                {0, 0, 1, 1},
                {0, 0, 1, 0},
                {0, 0, 0, 0},
        },
},
            {
        {
                {0, 0, 0, 0},
                {0, 0, 1, 1},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1},
        },
        {
                {0, 0, 0, 0},
                {0, 0, 1, 1},
                {0, 1, 1, 0},
                {0, 0, 0, 0},
        },
        {
                {0, 0, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1},
        }
},
        };
        public Form1()
        {
            InitializeComponent();

            Map_seting();
            Timer_seting();

            block_kinds = Rand(0, Block_count);
            block_x = Rand(0, 8);
            block_y = 1;
            block_spin = Rand(0, 4);

            next_block_kinds = Rand(0, Block_count);
            next_block_spin = Rand(0, 4);

            //Console.Clear();
            ScoreBox.Text = "score : " + score;
            Console.WriteLine("score : " + score);

            Make_NextBlock();
            Make_block();
        }
        private static void Print()
        {
            System.Console.Clear();
            for (int i = 0; i < 22; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    System.Console.Write(Map[i, j] + " ");
                }
                System.Console.WriteLine();
            }
        }
        private static void Make_NextBlock()
        {
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if (block[next_block_kinds, next_block_spin, i, j] == 1) Next_block[i, j].BackColor = block_color[next_block_kinds];
                }
            }
        }
        private static void Delete_NextBlock()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (block[next_block_kinds, next_block_spin, i, j] == 1) Next_block[i, j].BackColor = Color.White;
                }
            }
        }

        private static void Make_block()
        {
            for (int k = 0; ; k++)
            {
                if (Check_block(block_x, block_y + k, block_spin) == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block[block_kinds, block_spin, i, j] == 1) Map_block[block_y + k - 1 + i - 1, block_x + j - 1].BackColor = Color.DarkGray;
                        }
                    }
                    break;
                }
            }
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (block[block_kinds, block_spin, i, j] == 1) Map_block[block_y + i - 1, block_x + j - 1].BackColor = block_color[block_kinds];
                }
            }
        }
        private static void Delete_block()
        {
            for (int k = 0; ; k++)
            {
                if (Check_block(block_x, block_y + k, block_spin) == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block[block_kinds, block_spin, i, j] == 1) Map_block[block_y + k - 1 + i - 1, block_x + j - 1].BackColor = Color.White;
                        }
                    }
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (block[block_kinds, block_spin, i, j] == 1) Map_block[block_y + i - 1, block_x + j - 1].BackColor = Color.White;
                }
            }
        }
        private static bool Check_block(int x, int y, int spin)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (block[block_kinds, spin, i, j] == 1 && Map[y + i, x + j] == 1) return true;
                }
            }
            return false;
        }
        private static void Check_line()
        {
            int line_count = 0;
            for (int i = 1; i <= 20; i++) 
            {
                line_count = 0;
                for (int j = 1; j <= 10; j++) 
                {
                    if (Map[i, j] == 1) line_count++;
                }
                if(line_count == 10)
                {
                    for(int k = i; k > 1; k--)
                    {
                        for(int j = 1; j <= 10; j++)
                        {
                            Map[k, j] = Map[k - 1, j];
                            Map_block[k - 1, j - 1].BackColor = Map_block[k - 2, j - 1].BackColor;
                        }
                    }
                    for(int j=1;j<=10;j++)
                    {
                        Map[1, j] = 0;
                        Map_block[0, j - 1].BackColor = Color.White;
                    }
                    score++;
                }
            }
            Console.Clear();
            ScoreBox.Text = "score : " + score;
            Console.WriteLine("score : " + score);
        }
        private static int Rand(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }
        private static void Touch_block()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (block[block_kinds, block_spin, i, j] == 1) Map[block_y + i, block_x + j] = 1;
                }
            }

            Check_line();

            block_kinds = next_block_kinds;
            block_x = Rand(0, 8);
            block_y = 1;
            block_spin = next_block_spin;

            Delete_NextBlock();

            next_block_kinds = Rand(0, Block_count);
            next_block_spin = Rand(0, 4);

            Make_NextBlock();

            if (Check_block(block_x, block_y, block_spin) == true)
            {
                Gameover();
            }

            Make_block();

            
        }
        private static void Gameover()
        {
            myTimer.Stop();
            for (int i = 0; i < 20; i++) 
            {
                for (int j = 0; j < 10; j++) 
                {
                    Map_block[i, j].BackColor = Color.Red;
                    Map[i + 1, j + 1] = 0;
                }
            }

            if(MessageBox.Show("Game Over\nYour Score is "+ score +"\nYou want retry?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Map_block[i, j].BackColor = Color.White;
                    }
                }
                myTimer.Start();
                score = 0;
                Console.Clear();
                ScoreBox.Text = "score : " + score;
                Console.WriteLine("score : " + score);
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if(Check_block(block_x - 1, block_y, block_spin) == false)
                {
                    Delete_block();
                    block_x--;
                    Make_block();
                }
            }
            /*else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                if (Check_block(block_x, block_y - 1, block_spin) == false)
                {
                    Delete_block();
                    block_y--;
                    Make_block();
                }
            }*/
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                if (Check_block(block_x, block_y + 1, block_spin) == false)
                {
                    Delete_block();
                    block_y++;
                    Make_block();
                }
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                if (Check_block(block_x + 1, block_y, block_spin) == false)
                {
                    Delete_block();
                    block_x++;
                    Make_block();
                }
            }
            else if (e.KeyCode == Keys.Space)
            {
                int i = 0;
                Delete_block();
                for (; ; i++)
                {
                    if (Check_block(block_x, block_y + i, block_spin) == true)
                    {
                        break;
                    }
                }
                block_y = block_y + i - 1;
                Make_block();

                Touch_block();
            }
            else if (e.KeyCode == Keys.R)
            {
                if (Check_block(block_x, block_y, ((block_spin + 1 == 4) ? 0 : block_spin + 1)) == false)
                {
                    Delete_block();
                    block_spin++;
                    if (block_spin == 4) block_spin = 0;
                    Make_block();
                }
            }
            else if(e.KeyCode == Keys.E)
            {
                SaveBlock();
            }
        }

        static Timer myTimer = new Timer();
        static int alarmCounter = 1;

        // 1초에 한번 실행
        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {

            if (Check_block(block_x, block_y + 1, block_spin) == false)
            {
                Delete_block();
                block_y++;
                Make_block();
            }
            else
            {
                Touch_block();
            }

            //Console.WriteLine(alarmCounter + "second...");
            
            alarmCounter += 1;
            myTimer.Enabled = true;
        }

        private static void Make_SaveBlock()
        {
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if (block[save_block_kinds, save_block_spin, i, j] == 1) Save_block[i, j].BackColor = block_color[save_block_kinds];
                }
            }
        }

        private static void Delete_SaveBlock()
        {
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if (block[save_block_kinds, save_block_spin, i, j] == 1) Save_block[i, j].BackColor = Color.White;
                }
            }
        }

        private static void SaveBlock()
        {
            Delete_block();

            if(save_block_kinds == -1)
            {
                save_block_kinds = block_kinds;
                save_block_spin = block_spin;
                Make_SaveBlock();

                block_kinds = next_block_kinds;
                block_x = Rand(0, 8);
                block_y = 1;
                block_spin = next_block_spin;

                Delete_NextBlock();

                next_block_kinds = Rand(0, Block_count);
                next_block_spin = Rand(0, 4);

                Make_NextBlock();

                return;
            }
            else
            {
                Delete_SaveBlock();
                int save_kinds = save_block_kinds;
                int save_spin = save_block_spin;
                save_block_kinds = block_kinds;
                save_block_spin = block_spin;
                Make_SaveBlock();

                block_kinds = save_kinds;
                block_x = Rand(0, 8);
                block_y = 1;
                block_spin = save_spin;
            }

            Make_NextBlock();

            if (Check_block(block_x, block_y, block_spin) == true)
            {
                Gameover();
            }

            Make_block();

        }

        private void Map_seting()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Map_block[i, j] = new PictureBox();
                    ((ISupportInitialize)(Map_block[i, j])).BeginInit();
                    Map_block[i, j].BackColor = Color.White;
                    Map_block[i, j].Location = new Point(2 + j * 22, 2 + i * 22);
                    Map_block[i, j].Name = "Map_block[" + i + "," + j + "]";
                    Map_block[i, j].Size = new Size(20, 20);
                    Map_block[i, j].TabIndex = 0;
                    Map_block[i, j].TabStop = false;
                }
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Controls.Add(Map_block[i, j]);
                    ((ISupportInitialize)(Map_block[i, j])).EndInit();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Next_block[i, j] = new PictureBox();
                    ((ISupportInitialize)(Next_block[i, j])).BeginInit();
                    Next_block[i, j].BackColor = Color.White;
                    Next_block[i, j].Location = new Point(222 + 25 + 2 + j * 22, 25 + 2 + i * 22);
                    Next_block[i, j].Name = "Next_block[" + i + "," + j + "]";
                    Next_block[i, j].Size = new Size(20, 20);
                    Next_block[i, j].TabIndex = 0;
                    Next_block[i, j].TabStop = false;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Controls.Add(Next_block[i, j]);
                    ((ISupportInitialize)(Next_block[i, j])).EndInit();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Save_block[i, j] = new PictureBox();
                    ((ISupportInitialize)(Save_block[i, j])).BeginInit();
                    Save_block[i, j].BackColor = Color.White;
                    Save_block[i, j].Location = new Point(222 + 25 + 2 + j * 22, 325 + 2 + i * 22);
                    Save_block[i, j].Name = "Save_block[" + i + "," + j + "]";
                    Save_block[i, j].Size = new Size(20, 20);
                    Save_block[i, j].TabIndex = 0;
                    Save_block[i, j].TabStop = false;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Controls.Add(Save_block[i, j]);
                    ((ISupportInitialize)(Save_block[i, j])).EndInit();
                }
            }

            ScoreBox = new Label();

            ScoreBox.AutoSize = true;
            ScoreBox.Location = new Point(222, 22 * 4 + 50);
            ScoreBox.Name = "ScoreBox";
            ScoreBox.ForeColor = Color.White;
            ScoreBox.Font = new Font("Score : 0", 15, FontStyle.Bold);
            Console.WriteLine(ScoreBox.Size);
            ScoreBox.TabIndex = 1;

            this.Controls.Add(ScoreBox);
        }

        private void Timer_seting()
        {
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 1000;
            myTimer.Start();
        }
        
    }
}
