import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../../../classes/recipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeService } from '../../../services/recipe-service.service';
import { UserService } from '../../../services/user-service.service';
import { Category } from '../../../classes/category';
import { ZmanPipe } from "../../../zman.pipe";
import { User } from '../../../classes/user';

@Component({
    selector: 'app-recipe-details',
    standalone: true,
    templateUrl: './recipe-details.component.html',
    styleUrl: './recipe-details.component.css',
    imports: [FormsModule, ReactiveFormsModule, CommonModule, ZmanPipe]
})

  export class RecipeDetailsComponent implements OnInit {

    recipe?: Recipe;
    categories: Category[] = [];
    currentUser: string | null = sessionStorage.getItem('currentUser');
  
    constructor(private route: ActivatedRoute, private router: Router, private recipeService: RecipeService, private userService: UserService) { }
  
    
    ngOnInit(): void {
      this.route.params.subscribe(params => {
        
        const id = params['id'];
        this.recipeService.getRecipeById(id)
        .subscribe(recipe => this.recipe = recipe);
      })
      this.categories = [
        new Category(0, 'desserts', '🧁'),
        new Category(1, 'cakes & cookies', '🍩'),
        new Category(2, 'health', '🥗'),
        new Category(3, 'fish', '🍴'),
        new Category(4, 'soup', '🍟'),
      ]
    }
 
  
  range(n: number | undefined) {
    if (n === undefined) {
      return [];
    }
    return Array(n).fill(0).map((x, i) => i);
  }
  
  
  
    getRecipe(): void {
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.recipeService.getRecipeById(id)
        .subscribe(recipe => this.recipe = recipe);
    }


    isCurrentUser(): boolean {
      if (this.recipe?.userId == null) {
        return false;
      }
      const currentUser = sessionStorage.getItem('currentUser');
      if (!currentUser) {
        console.error('currentUser is not found in sessionStorage');
        return false;
      }
      
      const parsedObject = JSON.parse(currentUser);
      const id = parsedObject.id;
       console.log("נכנס לאתר",id); 
     
      return id == this.recipe?.userId;
    }
    
    

    deleteRecipe(): void {
      if (this.currentUser && this.recipe) {
        this.recipeService.deleteRecipe(this.recipe.id)
          .subscribe(() => {
            this.router.navigate(['/all-recipes']);
          });
      } else {
        console.error('Cannot delete recipe. Current user is not authenticated.');
      }
    }
  }
