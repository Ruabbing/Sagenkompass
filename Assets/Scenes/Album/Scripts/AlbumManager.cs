using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumManager : MonoBehaviour 
{

	#region Variable Declarations
	// Serialized Fields
	[SerializeField] private AlbumPage[] pages;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject backButton;



    // Private
    public int pageIndex;
	#endregion
	
	
	
	#region Public Properties
	
	#endregion
	
	
	
	#region Unity Event Functions
	private void Start () 
	{
		foreach(AlbumPage page in pages)
        {
            page.CheckSave();
        }
	}
	#endregion
	
	
	
	#region Public Functions
	public void NextPage()
	{
        
        //First Page
        //Everyother Page
		//Last Page

		if(pageIndex == 0)
		{
            pages[pageIndex].gameObject.SetActive(false);
            pages[pageIndex + 1].gameObject.SetActive(true);
            pages[pageIndex + 2].gameObject.SetActive(true);
			pageIndex += 2;
			backButton.SetActive(true);
        }
		else if(pageIndex < pages.Length - 2)
		{
            pages[pageIndex].gameObject.SetActive(false);
            pages[pageIndex - 1].gameObject.SetActive(false);
            pages[pageIndex + 1].gameObject.SetActive(true);
            pages[pageIndex + 2].gameObject.SetActive(true);
            pageIndex += 2;
            backButton.SetActive(true);
        }
		else
		{
            pages[pageIndex].gameObject.SetActive(false);
            pages[pageIndex - 1].gameObject.SetActive(false);
            pages[pageIndex + 1].gameObject.SetActive(true);
            pageIndex += 1;
			nextButton.SetActive(false);
        }

    }

    public void PreviousPage()
    {
        if (pageIndex == 2)
        {
            //to first page
            pages[pageIndex].gameObject.SetActive(false);
            pages[pageIndex - 1].gameObject.SetActive(false);
            pages[pageIndex - 2].gameObject.SetActive(true);
            pageIndex -= 2;
            backButton.SetActive(false);
        }
        else if (pageIndex < pages.Length - 1)
        {
            pages[pageIndex].gameObject.SetActive(false);
            pages[pageIndex - 1].gameObject.SetActive(false);
            pages[pageIndex - 2].gameObject.SetActive(true);
            pages[pageIndex - 3].gameObject.SetActive(true);
            pageIndex -= 2;
        }
        else
        {
            pages[pageIndex].gameObject.SetActive(false);
            pages[pageIndex - 1].gameObject.SetActive(true);
            pages[pageIndex - 2].gameObject.SetActive(true);
            pageIndex -= 1;
            nextButton.SetActive(true);
        }
    }
    #endregion



    #region Private Functions

    #endregion



    #region Coroutines

    #endregion
}