using KanaTrainer.Models;
using KanaTrainer.Services;
using KanaTrainer.Stores;
using KanaTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KanaTrainer
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private readonly KanaSystemsStore _kanaSystemsStore;
        private readonly TrainingStore _trainingStore;
        private readonly TrainingSettingsStore _trainingSettingsStore;

        private readonly NavigationStore _navigationStore;
        private readonly INavigationService _kanaTrainerNavigationService;
        private readonly INavigationService _trainingSettingsNavigationService;

        public App()
        {            
            _kanaSystemsStore = new KanaSystemsStore();
            _trainingSettingsStore = new TrainingSettingsStore(_kanaSystemsStore.KanaSystems[0]);
            _trainingStore = new TrainingStore(_trainingSettingsStore);

            _navigationStore = new NavigationStore();
            _kanaTrainerNavigationService = CreateKanaTrainerNavigationService();
            _trainingSettingsNavigationService = CreateTrainingSettingsNavigationService();
            
        }
        protected void App_Startup(object sender, StartupEventArgs e)
        {
            _kanaTrainerNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
        }

        private INavigationService CreateKanaTrainerNavigationService()
        {
            return new LayoutNavigationService<KanaTrainerViewModel>(
                _navigationStore,
                () => new KanaTrainerViewModel(_trainingStore),
                () => new NavigationBarViewModel(_trainingSettingsNavigationService));
        }

        private INavigationService CreateTrainingSettingsNavigationService()
        {
            return new NavigationService<TrainingSettingsViewModel>(
                _navigationStore,
                () => new TrainingSettingsViewModel(_trainingSettingsStore, _kanaSystemsStore, _kanaTrainerNavigationService));
        }
    }
}