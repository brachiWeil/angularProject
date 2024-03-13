
  import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
  import { ActivatedRoute, Router } from '@angular/router';
import { Recipe } from '../../../classes/recipe';
import { RecipeService } from '../../../services/recipe-service.service';
import { Category } from '../../../classes/category';
  
  
  @Component({
    selector: 'app-edit-recipe',
    templateUrl: './edit-recipe.component.html',
    styleUrls: ['./edit-recipe.component.css'],
    standalone: true,
    imports: [FormsModule, ReactiveFormsModule,CommonModule],
  
  })
  export class EditRecipeComponent implements OnInit {
    recipe: Recipe = new Recipe(0, '', 0, 0, 0, [], [], 0, '');
    ingredientInput: string = ''; // קלט חדש של מרכיב

    instructionInput: string = ''; // קלט חדש של הוראה

    constructor(private route: ActivatedRoute, private router: Router, private recipeService: RecipeService) { }
  
    ngOnInit(): void {
      const id = Number(this.route.snapshot.paramMap.get('id'));
      this.recipeService.getRecipeById(id).subscribe(recipe => {
        this.recipe = recipe;
      });
    }
    
    
    saveChanges(): void {
      this.recipeService.updateRecipe(this.recipe).subscribe(() => {
        this.router.navigate(['/all-recipes']); 
      });
    }
  
    cancel(): void {
      this.router.navigate(['/all-recipes']); 
    }
   
 
   // הוספת מרכיב לרשימת המרכיבים
   addIngredient(): void {
    if (this.ingredientInput.trim()) {
      this.recipe.ingredients.push(this.ingredientInput);
      this.ingredientInput = ''; // איפוס קלט
    }
    
  }
  // הוספת הוראה לרשימת ההוראות
  addInstruction(): void {
    if (this.instructionInput.trim()) {
      this.recipe.instructions.push(this.instructionInput);
      this.instructionInput = ''; // איפוס קלט
    }
  }

  
  }  
