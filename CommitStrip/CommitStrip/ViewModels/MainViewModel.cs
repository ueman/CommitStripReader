﻿using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using CommitStrip.Core.Models;
using CommitStrip.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CommitStrip.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        #region Properties

        private ICommitStripDownloadService DownloadService { get; set; }

        private IUserDialogs DialogService { get; set; }

        private bool _laoding;
        public bool Loading
        {
            get { return _laoding; }
            set
            {
                _laoding = value;
                RaisePropertyChanged(() => Loading);
                RaisePropertyChanged(() => NotLoading);
            }
        }

        public bool NotLoading => !Loading;
            
        private List<CommitStripItem> _comics; 
        public List<CommitStripItem> Comics {
            get
            {
                return _comics;
                
            }
            set
            {
                _comics = value;
                RaisePropertyChanged(() => Comics);
            }
        }

        private int _page;
        public int Page
        {
            get { return _page; }
            set
            {
                _page = value;
                RaisePropertyChanged(() => Page);
                OpenPage(_page);
            }
        }

        #endregion


        public MainViewModel(   INetworkConnectivityService connectivityService,
                                ICommitStripDownloadService downloadService) : base (connectivityService)
        {
            DownloadService = downloadService;
            DownloadService.DownloadHandler += DownloadHandler;
        }

        public void Init()
        {
            Title = "CommitStrip";
            Page = 1;
            DialogService = Mvx.Resolve<IUserDialogs>();
        }


        public void DownloadHandler(DownloadInformation info)
        {
            if (info.Status == DownloadStatus.Success)
            {
                Comics = DownloadService.Comics;
                Loading = false;
            }
            else if (info.Status == DownloadStatus.Failed)
            {
                DialogService.Alert("Downloading failed", "", "Ok");
            }
            else
            {
                DialogService.Alert("This page doesn't exist", "", "Ok");
            }
        }

        private void OpenPage(int page)
        {
            if (ConnectivityService.IsConnected())
            {
                Loading = true;
                DownloadService.DownloadComics(page);
            }
            else
            {
                DialogService.Alert("There is no network connection", "No Network Connection", "Ok");
            }
        }

        #region Commands

        private MvxCommand<CommitStripItem> _selectComic;
        public IMvxCommand SelectComicCommand
        {
            get
            {
                _selectComic = _selectComic ?? new MvxCommand<CommitStripItem>(SelectComic);
                return _selectComic;
            }
        }

        private void SelectComic(CommitStripItem item)
        {
            ShowViewModel<ComicDetailViewModel>(new { comic = item.Description, title = item.Title });
        }

        private MvxCommand _previousPageCommand;
        public IMvxCommand OpenPreviousPageCommand
        {
            get
            {
                _previousPageCommand = _previousPageCommand ?? new MvxCommand(OpenPreviousPage);
                return _previousPageCommand;
            }
        }

        private void OpenPreviousPage()
        {
            if (Page == 1) return;
            Page -= 1;
        }

        private MvxCommand _nextPageCommand;
        public IMvxCommand OpenNextPageCommand
        {
            get
            {
                _nextPageCommand = _nextPageCommand ?? new MvxCommand(OpenNextPage);
                return _nextPageCommand;
            }
        }

        private void OpenNextPage()
        {
            Page += 1;
        }

        private MvxCommand _openSettingsCommand;
        public IMvxCommand OpenSettingsPageCommand
        {
            get
            {
                _openSettingsCommand = _openSettingsCommand ?? new MvxCommand(OpenSettingsPage);
                return _openSettingsCommand;
            }
        }

        private void OpenSettingsPage()
        {
            ShowViewModel<SettingsViewModel>();
        }

        #endregion
    }
}