<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Product;


class ProductController extends Controller
{

public function index()
{
    $products = Product::paginate(10); // یا هر عدد دلخواه برای هر صفحه
    return view('products.index', compact('products'));
}


public function create()
{
    return view('products.create');
}

public function store(Request $request)
{
    $validated = $request->validate([
        'name' => 'required|string|max:255',
        'category' => 'required|string|max:255',
        'quantity' => 'required|integer|min:0',
        'price_per_unit' => 'required|numeric|min:0',
    ]);

    Product::create($validated);

    return redirect()->route('products.index')->with('success', 'محصول با موفقیت اضافه شد.');
}


public function destroy($id)
{
    $product = Product::findOrFail($id);
    $product->delete();

    return redirect()->route('products.index')->with('success', 'محصول با موفقیت حذف شد.');
}


public function edit($id)
{
    $product = Product::findOrFail($id);
    return view('products.edit', compact('product'));
}


public function update(Request $request, $id)
{
    $request->validate([
        'name' => 'required|string|max:255',
        'category' => 'required|string|max:255',
        'quantity' => 'required|integer|min:0',
        'price_per_unit' => 'required|numeric|min:0',
    ]);

    $product = Product::findOrFail($id);
    $product->update([
        'name' => $request->name,
        'category' => $request->category,
        'quantity' => $request->quantity,
        'price_per_unit' => $request->price_per_unit,
    ]);

    return redirect()->route('products.index')->with('success', 'محصول با موفقیت ویرایش شد.');
}


public function show($id)
{
    $product = Product::findOrFail($id);
    return view('products.show', compact('product'));
}


}
