﻿namespace Pokedex;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new Tabs());

        NavigationPage.SetHasNavigationBar(this, false);
    }
}
