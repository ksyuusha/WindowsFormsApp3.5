using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        // Список для хранения задач
        private List<Task> tasks = new List<Task>();

        public Form1()
        {
            InitializeComponent();
            UpdateTaskList(); // Обновление списка задач при загрузке формы
        }

        // Обработчик для добавления задачи
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            if (!string.IsNullOrEmpty(taskName))
            {
                tasks.Add(new Task { Name = taskName, IsCompleted = false });
                txtTaskName.Clear();
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Введите имя задачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обработчик для удаления задачи
        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)lstTasks.SelectedItem;
                tasks.Remove(selectedTask);
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Обработчик для отметки задачи как выполненной
        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem != null)
            {
                Task selectedTask = (Task)lstTasks.SelectedItem;
                selectedTask.IsCompleted = !selectedTask.IsCompleted; // Переключение состояния выполнения
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Выберите задачу для отметки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Метод для обновления списка задач
        private void UpdateTaskList()
        {
            lstTasks.DataSource = null; // Очищаем источник данных
            lstTasks.DataSource = tasks; // Устанавливаем новый источник данных
            lstTasks.DisplayMember = "Display"; // Указываем, что будем отображать свойство Display
        }
    }

    // Класс для представления задачи
    public class Task
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        // Свойство для отображения задачи
        public string Display => $"{(IsCompleted ? "[✓]" : "[ ]")} {Name}";

        public override string ToString()
        {
            return Display;
        }
    }
}
